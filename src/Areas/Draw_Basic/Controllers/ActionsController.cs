using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Draw_Basic.Controllers
{
    public class ActionsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateSprite(string button)
        {
            RectSprite sprite = new RectSprite
            {
                SpriteID = "Sprite1",
                Width = 100,
                Height = 100,
                X = 150,
                Y = 150,
                FillStyle = "green"
            };

            var container = this.GetCmp<DrawContainer>("Draw1");
            container.Add(sprite);
            container.RenderFrame();

            return this.Direct();
        }

        public ActionResult ChangeColor(string button)
        {
            DrawContainer dc = this.GetCmp<DrawContainer>("Draw1");
            dc.GetSprite("Sprite1").SetAttributes(new Sprite { FillStyle = "red" });
            dc.RenderFrame();

            return this.Direct();
        }

        public ActionResult RotateLeft(string button)
        {
            DrawContainer dc = this.GetCmp<DrawContainer>("Draw1");
            dc.GetSprite("Sprite1").SetAttributes(new Sprite { RotationDegrees = -45 });
            dc.RenderFrame();

            return this.Direct();
        }

        public ActionResult RotateRight(string button)
        {
            DrawContainer dc = this.GetCmp<DrawContainer>("Draw1");
            dc.GetSprite("Sprite1").SetAttributes(new Sprite
            {
                Duration = 1000,
                RotationDegrees = 0,
                Easing = Easing.ElasticIn
            });
            dc.RenderFrame();

            return this.Direct();
        }

        public ActionResult Scaling(string button)
        {
            DrawContainer dc = this.GetCmp<DrawContainer>("Draw1");
            dc.GetSprite("Sprite1").SetAttributes(new Sprite { ScalingX = 2, ScalingY = 2, Duration = 0 });
            dc.RenderFrame();

            return this.Direct();
        }

        public ActionResult Translation(string button)
        {
            DrawContainer dc = this.GetCmp<DrawContainer>("Draw1");
            dc.GetSprite("Sprite1").SetAttributes(new Sprite { TranslationX = -100, TranslationY = -100 });
            dc.RenderFrame();

            return this.Direct();
        }
    }
}
