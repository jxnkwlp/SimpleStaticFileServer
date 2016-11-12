using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace SimpleStaticFileServerForms.Code
{
    static class XmlConfigHelper
    {
        static string XmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SimpleStaticFileServerForms.config");

        //static XDocument GetDocument()
        //{
        //    f(!File.Exists(XmlPath))
        //        return null;

        //    string content = File.ReadAllText(XmlPath);

        //    XDocument doc = new XDocument(content);

        //    return doc;
        //}

        public static IList<Site> GetSites()
        {
            if (!File.Exists(XmlPath))
                return new List<Site>();

            try
            {
                XmlSerializer xmlSer = new XmlSerializer(typeof(List<Site>));

                using (var fs = new FileStream(XmlPath, FileMode.OpenOrCreate))
                {
                    return (List<Site>)xmlSer.Deserialize(fs);
                }
            }
            catch (Exception)
            {
                File.Delete(XmlPath);
            }

            return new List<Site>();
        }

        public static int GetPort(string path)
        {
            var site = GetSites().FirstOrDefault(t => t.Path.Equals(path, StringComparison.InvariantCultureIgnoreCase));

            return site == null ? 0 : site.Port;
        }

        public static void AddOrUpdate(string path, int port)
        {
            AddOrUpdate(new Site() { Path = path, Port = port });
        }

        public static void AddOrUpdate(Site site)
        {
            var sites = GetSites();


            if (!sites.Any(t => t.Path.Equals(site.Path, StringComparison.InvariantCultureIgnoreCase)))
            {
                sites.Add(site);
            }
            else
            {
                var site2 = sites.FirstOrDefault(t => t.Path.Equals(site.Path, StringComparison.InvariantCultureIgnoreCase));
                site2.Port = site.Port;
            }

            Save(sites);
        }

        public static void Remove(string path)
        {
            var sites = GetSites();

            var site = sites.FirstOrDefault(t => t.Path.Equals(path, StringComparison.InvariantCultureIgnoreCase));

            if (site != null)
            {
                sites.Remove(site);

                Save(sites);
            }


        }

        static void Save(IList<Site> sites)
        {
            XmlSerializer xmlSer = new XmlSerializer(typeof(List<Site>));

            using (var fs = new FileStream(XmlPath, FileMode.OpenOrCreate))
            {
                xmlSer.Serialize(fs, sites);
            }
        }
    }

}
