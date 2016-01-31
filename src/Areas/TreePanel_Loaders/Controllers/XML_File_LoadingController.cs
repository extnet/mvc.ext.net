using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Web.UI.WebControls;

namespace Ext.Net.MVC.Examples.Areas.TreePanel_Loaders.Controllers
{
    public class XML_File_LoadingController : Controller
    {
        public ActionResult Index()
        {
            var doc = new XmlDocument();
            doc.Load(this.Server.MapPath("~/Areas/TreePanel_Loaders/Content/authors.xml"));

            XmlDataSource xmldataSource = new XmlDataSource();
            xmldataSource.Data = doc.OuterXml;
            xmldataSource.ID = DateTime.Now.Ticks.ToString();  // unique ID is required
            
            return View(xmldataSource);
        }
    }
}
