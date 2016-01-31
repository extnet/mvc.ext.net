using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.DataView_Basic.Controllers
{
    public class PagingController : Controller
    {
        public ActionResult Index()
        {
            string path = Server.MapPath("~/Areas/DataView_Basic/Content/images/thumbs");
            string[] files = System.IO.Directory.GetFiles(path);

            List<object> data = new List<object>(files.Length);
            foreach (string fileName in files)
            {
                System.IO.FileInfo fi = new System.IO.FileInfo(fileName);
                data.Add(new
                {
                    name = fi.Name,
                    url = Url.Content("~/Areas/DataView_Basic/Content/images/thumbs/") + fi.Name,
                    size = fi.Length,
                    lastmod = fi.LastAccessTime
                });
            }

            return View(data);
        }
    }
}
