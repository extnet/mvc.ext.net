using System.Collections.Generic;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Draw_Basic.Controllers
{
    public class AustraliaController : Controller
    {
        public ActionResult Index()
        {
            string[] colors = new string[] {
                        "#8D38C9",
                        "#00FFFF",
                        "#FF00FF",
                        "#008000",
                        "#FFFF00",
                        "#0000FF",
                        "#FF0000"
                };

            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.Load(Server.MapPath("~/Areas/Draw_Basic/Content/Australia.xml"));

            List<object> info = new List<object>();
            List<AbstractSprite> sprites = new List<AbstractSprite>();

            int i = 0;
            foreach (System.Xml.XmlNode state in doc.SelectNodes("states/state"))
            {
                PathSprite sprite = new PathSprite
                {
                    Path = state.SelectSingleNode("path").InnerText,
                    FillStyle = "#808080",
                    StrokeStyle = "#000",
                    LineWidth = 1,
                    Linejoin = StrokeLinejoin.Round
                    //Cursor = "pointer"
                };

                //sprite.Listeners.MouseOver.Handler = string.Format("onMouseOver(this, {0}, {1});", JSON.Serialize(colors[i]), i);
                //sprite.Listeners.MouseOut.Handler = "onMouseOut(this);";

                sprites.Add(sprite);
                i++;

                info.Add(new
                {
                    state = state.SelectSingleNode("name").InnerText,
                    desc = state.SelectSingleNode("description").InnerText
                });
            }

            ViewData["mapInfo"] = info;

            return View(sprites);
        }
    }
}
