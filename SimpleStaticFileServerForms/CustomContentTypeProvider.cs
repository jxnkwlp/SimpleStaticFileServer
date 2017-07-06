using Microsoft.Owin.StaticFiles.ContentTypes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleStaticFileServerForms
{
    class CustomContentTypeProvider : FileExtensionContentTypeProvider
    {
        public CustomContentTypeProvider()
        {
            var keys = ConfigurationManager.AppSettings.AllKeys;

            foreach (var key in keys)
            {
                if (key.Trim().StartsWith("mime", StringComparison.InvariantCultureIgnoreCase))
                {
                    var t = key.Trim().Remove(0, 4);

                    //if (Mappings.ContainsKey(t))
                    //{
                    //    Mappings.Remove(t);
                    //}
                    //Mappings.Add(t, ConfigurationManager.AppSettings[key].Trim());

                    Mappings[t] = ConfigurationManager.AppSettings[key].Trim();
                }
            }

        }
    }
}
