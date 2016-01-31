using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Events.Controllers
{
    /// <summary>
    /// Area name must be defined manually (if a controller belongs to an area)
    /// 
    /// Other useful options:
    /// - GenerateProxyForOtherAreas
    ///   If true then direct method proxy will be generated for all viewes in all areas, default false
    ///   
    /// - GenerateProxyForOtherControllers
    ///   If false then direct method proxy will be generated for particular controller views only, default true
    ///   
    /// - IDMode
    /// - Alias
    /// </summary>
    [DirectController(AreaName="Events")]
    public class DirectMethodController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [DirectMethod]
        public ActionResult SetTimeStamp()
        {
            var label = this.GetCmp<Label>("Label1");
            label.Text = DateTime.Now.ToLongTimeString();
            label.Element.Highlight();

            return this.Direct();
        }

        [DirectMethod]
        public ActionResult LogCompanyInfo(string name, int count)
        {
            string template = string.Concat("<b>{0}</b> has approximately <b>{1}</b> employees.");
            string[] employees = new string[4] { "1-5", "6-25", "26-100", "100+" };

            this.GetCmp<Label>("Label3").Html = string.Format(template, name, employees[count]);

            return this.Direct();
        }
    }
}
