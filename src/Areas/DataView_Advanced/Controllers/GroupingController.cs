using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace Ext.Net.MVC.Examples.Areas.DataView_Advanced.Controllers
{
    public class GroupingController : Controller
    {
        public ActionResult Index()
        {
            XElement document = XElement.Load(Server.MapPath("~/Areas/DataView_Advanced/Content/DashboardSchema.xml"));
            string defaultIcon = document.Attribute("defaultIcon") != null ? document.Attribute("defaultIcon").Value : "";

            IEnumerable<object> query = from g in document.Elements("group")
                select new
                {
                    Title = g.Attribute("title") != null ? g.Attribute("title").Value : "",
                    Items = (from i in g.Elements("item")
                                select new
                                {
                                    Title = i.Element("title") != null ? i.Element("title").Value : "",
                                    Icon = Url.Content("~/Areas/DataView_Advanced/Content/" + (i.Element("item-icon") != null ? i.Element("item-icon").Value : defaultIcon)),
                                    Id = i.Element("id") != null ? i.Element("id").Value : ""
                                }
                        )
                };
            return View(query);
        }
    }
}
