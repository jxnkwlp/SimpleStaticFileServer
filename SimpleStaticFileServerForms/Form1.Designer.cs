namespace SimpleStaticFileServerForms
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btn_open_brower = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_remove = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.label_selected = new System.Windows.Forms.ToolStripStatusLabel();
            this.folderDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btn_open_explorer = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Items.AddRange(new object[] {
            "E:\\wwroot\\",
            "E:\\wwroot_test\\"});
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(202, 256);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // btn_open_brower
            // 
            this.btn_open_brower.Enabled = false;
            this.btn_open_brower.Location = new System.Drawing.Point(220, 70);
            this.btn_open_brower.Name = "btn_open_brower";
            this.btn_open_brower.Size = new System.Drawing.Size(75, 23);
            this.btn_open_brower.TabIndex = 1;
            this.btn_open_brower.Text = "浏览器打开";
            this.btn_open_brower.UseVisualStyleBackColor = true;
            this.btn_open_brower.Click += new System.EventHandler(this.btn_open_brower_Click);
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(220, 12);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 23);
            this.btn_add.TabIndex = 1;
            this.btn_add.Text = "添加";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_remove
            // 
            this.btn_remove.Enabled = false;
            this.btn_remove.Location = new System.Drawing.Point(220, 41);
            this.btn_remove.Name = "btn_remove";
            this.btn_remove.Size = new System.Drawing.Size(75, 23);
            this.btn_remove.TabIndex = 1;
            this.btn_remove.Text = "删除";
            this.btn_remove.UseVisualStyleBackColor = true;
            this.btn_remove.Click += new System.EventHandler(this.btn_remove_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.label_selected});
            this.statusStrip1.Location = new System.Drawing.Point(0, 277);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(307, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // label_selected
            // 
            this.label_selected.Name = "label_selected";
            this.label_selected.Size = new System.Drawing.Size(71, 17);
            this.label_selected.Text = "E:\\wwroot\\";
            // 
            // btn_open_explorer
            // 
            this.btn_open_explorer.Enabled = false;
            this.btn_open_explorer.Location = new System.Drawing.Point(220, 99);
            this.btn_open_explorer.Name = "btn_open_explorer";
            this.btn_open_explorer.Size = new System.Drawing.Size(75, 23);
            this.btn_open_explorer.TabIndex = 1;
            this.btn_open_explorer.Text = "打开目录";
            this.btn_open_explorer.UseVisualStyleBackColor = true;
            this.btn_open_explorer.Click += new System.EventHandler(this.btn_open_explorer_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 299);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btn_remove);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.btn_open_explorer);
            this.Controls.Add(this.btn_open_brower);
            this.Controls.Add(this.listBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SimpleStaticFileServer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btn_open_brower;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_remove;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel label_selected;
        private System.Windows.Forms.FolderBrowserDialog folderDialog1;
        private System.Windows.Forms.Button btn_open_explorer;
    }
}

