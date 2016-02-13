using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Miscellaneous_Locale.Controllers
{
    public class BasicController : Controller
    {
        public ActionResult Index(string lang)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            foreach (CultureInfo culture in Ext.Net.ResourceManager.SupportedCultures)
            {
                values.Add(culture.EnglishName, culture.ToString());
            }

            string cultureName;
            if (string.IsNullOrEmpty(lang) || lang == "Ignore")
            {
                bool isParent;
                if (Request.UserLanguages != null && ResourceManager.IsSupportedCulture(Request.UserLanguages[0], out isParent))
                    cultureName = isParent ? Request.UserLanguages[0].Split(new char[] { '-' })[0] : Request.UserLanguages[0];
                else
                    cultureName = "en";
            } else
                cultureName = lang;

            Thread.CurrentThread.CurrentCulture = new CultureInfo(cultureName);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureName);
            ViewData["lang"] = cultureName;

            return View(values);
        }
    }
}
