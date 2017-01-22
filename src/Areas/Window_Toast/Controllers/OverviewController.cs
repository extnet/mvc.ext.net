using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Window_Toast.Controllers
{
    public class OverviewController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public DirectResult Button1_Click()
        {
            X.Toast("Toast shown!");
            return this.Direct();
        }

        public DirectResult Button2_Click()
        {
            X.Toast("Toast with title at bottom shown!", "MyTitle", ToastAlign.Bottom);
            return this.Direct();
        }

        public DirectResult Button3_Click()
        {
            object toastObj = new
            {
                html = "This toast was defined from code behind from an anonymous object!",
                title = "Object toast",
                align = JSON.EnumToString(ToastAlign.Right), // Map the enum to the client-side supported string.
                anchor = "Button3",
                stickWhileHover = true,
                closeOnMouseDown = true,
                autoClose = true,
                autoCloseDelay = 2500
            };

            X.Toast(toastObj);

            return this.Direct();
        }

        public DirectResult Button4_Click()
        {
            var toastComp = new Toast()
            {
                Html = "This toast was defined from code behind from an Ext.Net.Toast component definition!",
                Title = "Object toast",
                Align = ToastAlign.Right,
                Anchor = "Button3",
                StickWhileHover = true,
                CloseOnMouseDown = true,
                AutoClose = true,
                AutoCloseDelay = 2500
            };

            X.Toast(toastComp);

            return this.Direct();
        }
    }
}