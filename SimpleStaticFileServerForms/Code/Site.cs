using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SimpleStaticFileServerForms.Code
{
    [Serializable]
    public class Site
    {
        public string Path { get; set; }

        public int Port { get; set; }
    }
}
