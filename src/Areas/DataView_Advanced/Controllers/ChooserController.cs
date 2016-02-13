using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.DataView_Advanced.Controllers
{
    public class ChooserController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateChooser()
        {
            return this.PartialExtView("ChooserDialog");
        }

        public ActionResult GetImages()
        {
            string path = "~/Areas/DataView_Basic/Content/images/touch-icons/";
            string serverPath = Server.MapPath(path);
            string[] files = System.IO.Directory.GetFiles(serverPath);

            List<object> data = new List<object>(files.Length);

            foreach (string fileName in files)
            {
                System.IO.FileInfo fi = new System.IO.FileInfo(fileName);
                long size = fi.Length;
                string strSize = size < 1024 ? size + " bytes" : (Math.Round(((size * 10.0) / 1024)) / 10) + " KB";
                data.Add(new
                {
                    name = fi.Name,
                    url = Url.Content(path + fi.Name),
                    sizeString = strSize,
                    size = size
                });
            }

            return this.Store(data);
        }
    }
}
