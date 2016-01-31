using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Draw_Basic.Controllers
{
    public class AnimationController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AnimateRect()
        {
            DrawContainer dc = X.GetCmp<DrawContainer>("Draw1");
            dc.GetSprite("rectangles").SetAttributes(new Sprite
            {
                Duration = 1000,
                TranslationX = 150
            });
            dc.RenderFrame();

            return this.Direct();
        }
    }
}
