using Ext.Net;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Form_TextField.InputMask_Native.Controllers
{
    public class InputMask_NativeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HandleBtnClick()
        {
            var pattern = "99/99/9999";

            // Getting the TextField dynamically does not mean its input mask will not be null,
            // so the only way here is to call the actual client-side scripts.
            X.AddScript("App.TextField1.setNote('" + pattern + "');");
            X.AddScript("App.TextField1.inputMask.setPattern('" + pattern + "');");

            return new DirectResult();
        }
    }
}
