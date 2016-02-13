using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_ColumnModel.HyperlinkColumn.Controllers
{
    public class HyperlinkColumnController : Controller
    {
        public ActionResult Index()
        {
            return View(new object[]
            {
                new object[] { "company name 1", "companyId1" },
                new object[] { "company name 2", "companyId2" },
                new object[] { "company name 3", "companyId3" }
            });
        }

        public ActionResult Update()
        {
            Ext.Net.HyperlinkColumn hlc = X.GetCmp<Ext.Net.HyperlinkColumn>("HyperlinkColumn1");
            hlc.Pattern = "{text:capitalize}";
            hlc.HrefPattern = "http://ext.net?companyId={href}&someParamMore=hello";
            hlc.UpdatePatternTpl();
            X.GetCmp<GridPanel>("GridPanel1").Refresh();

            return this.Direct();
        }
    }
}
