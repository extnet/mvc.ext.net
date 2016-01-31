using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ext.Net.MVC.Examples.Areas.TreePanel_Advanced.Models
{
    public class Image_OrganizerModel
    {
        public static object GetFiles(string path)
        {
            string dir = HttpContext.Current.Server.MapPath(path);
            string[] files = System.IO.Directory.GetFiles(dir);

            List<object> data = new List<object>(files.Length);

            foreach (string fileName in files)
            {
                System.IO.FileInfo fi = new System.IO.FileInfo(fileName);

                data.Add(new
                {
                    name = fi.Name,
                    url = path + "/" + fi.Name
                });
            }

            return data;
        }
    }
}