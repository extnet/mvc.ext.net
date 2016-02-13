using System;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.XRender_Basic.Controllers
{
    public class New_WindowController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Button1_Click()
        {
            Window win = new Window
            {
                ID = "Window1",
                Title = "Example",
                Height = 185,
                Width = 350,
                BodyPadding = 5,
                Modal = true,
                CloseAction = CloseAction.Destroy,
                Html = "A new Window  was created at: " + DateTime.Now.ToLongTimeString()
            };

            win.Render(RenderMode.Auto);

            return this.Direct();
        }
    }
}
