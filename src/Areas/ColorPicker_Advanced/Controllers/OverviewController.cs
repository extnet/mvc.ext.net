using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Colorpicker_Advanced.Controllers
{
    public class OverviewController : Controller
    {
        // GET: Colorpicker_Advanced/Overview
        public ActionResult Index()
        {
            return View();
        }

        public RestResult HandleFieldChange(string previousColor, string color)
        {
            return new RestResult()
            {
                Success = true,
                Message = "From server-side handler (MVC action): Changed color from " + previousColor + " to " + color + "."
            };
        }
    }
}