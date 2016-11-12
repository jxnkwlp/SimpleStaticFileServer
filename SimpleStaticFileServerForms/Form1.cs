using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using SimpleStaticFileServerForms.Code;
using Microsoft.Owin.Hosting;
using Owin;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;

namespace SimpleStaticFileServerForms
{
    public partial class Form1 : Form
    {
        Dictionary<string, int> siteList = new Dictionary<string, int>();
        Dictionary<string, bool> runList = new Dictionary<string, bool>();

        public Form1()
        {
            InitializeComponent();

            this.AllowDrop = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label_selected.Text = "";

            LoadConfig();
        }


        private void LoadConfig()
        {
            var sites = XmlConfigHelper.GetSites();

            listBox1.Items.Clear();

            if (sites != null)
                listBox1.Items.AddRange(sites.Select(t => t.Path).ToArray());

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                btn_open_brower.Enabled = false;
                btn_open_explorer.Enabled = false;
                btn_remove.Enabled = false;

                return;
            }
            else
            {
                btn_open_brower.Enabled = true;
                btn_open_explorer.Enabled = true;
                btn_remove.Enabled = true;

                label_selected.Text = listBox1.SelectedItem.ToString();
                label_selected.ToolTipText = label_selected.Text;
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (folderDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedPath = folderDialog1.SelectedPath;

                if (!Directory.Exists(selectedPath))
                {
                    MessageBox.Show(string.Format("选择的文件夹'{0}'不存在！", selectedPath));
                }
                else
                {
                    if (!listBox1.Items.Cast<string>().Any(t => t.Equals(selectedPath)))
                    {
                        listBox1.Items.Add(selectedPath);

                        XmlConfigHelper.AddOrUpdate(new Code.Site() { Path = selectedPath });

                    }
                }
            }
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            string selectPath = listBox1.SelectedItem.ToString();

            listBox1.Items.Remove(selectPath);

            XmlConfigHelper.Remove(selectPath);
        }



        void AddOrRemoveList()
        {

        }

        private void btn_open_explorer_Click(object sender, EventArgs e)
        {
            var selectPath = listBox1.SelectedItem.ToString();

            System.Diagnostics.Process.Start(selectPath);
        }

        private void btn_open_brower_Click(object sender, EventArgs e)
        {
            var selectPath = listBox1.SelectedItem.ToString();

            int port = XmlConfigHelper.GetPort(selectPath);

            if (!siteList.ContainsKey(selectPath))
            {
                siteList[selectPath] = port;
            }

            if (siteList[selectPath] < 1000)
            {
                siteList[selectPath] = RandPort();
            }

            if (!Directory.Exists(selectPath))
            {
                MessageBox.Show("目录" + selectPath + "不存在！");
                XmlConfigHelper.Remove(selectPath);
                return;
            }

            XmlConfigHelper.AddOrUpdate(selectPath, siteList[selectPath]);

            bool success = true;
            int tryCount = 1;

            do
            {
                success = true;

                if (tryCount > 10)
                {
                    break; ;
                }

                try
                {
                    tryCount++;

                    Open(selectPath);
                }
                catch (Exception)
                {
                    success = false;

                    // 端口错误。

                    siteList[selectPath] = RandPort();
                }

            } while (!success);


        }


        void Open(string path)
        {
            int port = siteList[path];

            string url = string.Format("{0}:{1}", "http://127.0.0.1", port);

            if (!runList.ContainsKey(path))
            {
                runList[path] = false;
            }

            if (!runList[path])
            {
                // WebApp.Start (new StartOptions(url) { AppStartup = typeof(Startup).AssemblyQualifiedName });

                WebApp.Start(new StartOptions(url), (app) =>
                {
                    var fileSystem = new PhysicalFileSystem(path);

                    var fileServerOptions = new FileServerOptions()
                    {
                        FileSystem = fileSystem,
                        EnableDefaultFiles = true,
                        EnableDirectoryBrowsing = true,
                    };

                    app.UseFileServer(fileServerOptions);
                });

                runList[path] = true;
            }

            System.Diagnostics.Process.Start(url);
        }

        int RandPort()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());

            return rand.Next(10000, 20000);
        }

        private void Form1_MinimumSizeChanged(object sender, EventArgs e)
        {
            HideForm();

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowForm();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;

                HideForm();

                this.notifyIcon1.BalloonTipText = "双击可以再次显示窗口";
                this.notifyIcon1.ShowBalloonTip(3);
            }

        }

        private void HideForm()
        {
            this.ShowInTaskbar = false;
            this.Hide();
        }

        private void ShowForm()
        {
            this.ShowInTaskbar = true;
            this.Focus();
            this.Activate();
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link;
        }

        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            string[] dirs = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (dirs != null)
            {
                foreach (var selectedPath in dirs)
                {
                    if (!Directory.Exists(selectedPath))
                    {
                        MessageBox.Show(string.Format("选择的文件夹'{0}'不存在！", selectedPath));
                    }
                    else
                    {
                        if (!listBox1.Items.Cast<string>().Any(t => t.Equals(selectedPath)))
                        {
                            listBox1.Items.Add(selectedPath);

                            XmlConfigHelper.AddOrUpdate(new Code.Site() { Path = selectedPath });
                        }
                    }
                }
            }

        }


    }

    //public class Startup
    //{
    //    public void Configuration(IAppBuilder app)
    //    {
    //        if (!Directory.Exists(Program.WebRoot))
    //        {
    //            Console.ForegroundColor = ConsoleColor.Red;
    //            Console.WriteLine("The directory '" + Program.WebRoot + "' not found!");
    //            Console.ResetColor();

    //            Console.WriteLine();

    //            return;
    //        }

    //        var root = Program.WebRoot;

    //        var fileSystem = new PhysicalFileSystem(root);

    //        var fileServerOptions = new FileServerOptions()
    //        {
    //            FileSystem = fileSystem,
    //            EnableDefaultFiles = true,
    //            EnableDirectoryBrowsing = true,
    //        };

    //        app.UseFileServer(fileServerOptions);
    //    }
    //}
}
