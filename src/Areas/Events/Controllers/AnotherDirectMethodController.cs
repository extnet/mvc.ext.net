using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Events.Controllers
{
    // Direct methods inside this controller will render own proxies for all views inside Events area (default behaviour for all DirectController)
    // Also namespace will be absent due defined IDMode
    // Direct method can be executted as
    // App.direct.GetTime()
    [DirectController(AreaName="Events", IDMode=DirectMethodProxyIDMode.None)]
    public class AnotherDirectMethodController : Controller
    {        
        [DirectMethod]
        public ActionResult GetTime()
        {
            return this.Direct(DateTime.Now.ToLongTimeString());
        }
    }
}
