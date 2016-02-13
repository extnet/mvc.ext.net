using System.Web.Mvc;
using System.Web.UI;

namespace Ext.Net.MVC.Examples.Areas.Element_Basic.Controllers
{
    [DirectController(AreaName = "Element_Basic")]
    public class LayerController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowRight(string sender)
        {
            Layer layer = new Layer(new LayerConfig
            {
                ID = "Layer1",
                DH =
                {
                    Cls = "layer",
                    Children = {
                        new DomObject {
                            Children = {
                                new DomObject {
                                    Tag = HtmlTextWriterTag.H3,
                                    Html = "Hello"
                                },
                                new DomObject {
                                    Tag = HtmlTextWriterTag.Hr
                                },
                                new DomObject {
                                    Tag = HtmlTextWriterTag.A,
                                    Html = "Close",
                                    CustomConfig = {
                                        new ConfigItem("href", "#", ParameterMode.Value),
                                        new ConfigItem("onClick", "App.direct.Element_Basic.Close('Layer1'); return false;", ParameterMode.Value)
                                    }
                                }
                            }
                        }
                    }
                }
            });

            layer.SetVisible(false, false).AlignTo(this.GetCmp<Panel>("Panel1").Element, "tl-tr", new int[] { 5, 0 }).SlideIn("l");

            this.GetCmp<Button>(sender).Disabled = true;

            return this.Direct();
        }

        public ActionResult ShowBottom(string sender)
        {
            Panel p = new Panel
            {
                ID = "Panel2",
                Title = "Panel in Layer",
                Html = "Ext.Net Panel",
                BodyPadding = 5,
                Width = 300,
                Height = 100,
                Floating = true,
                Shadow = false,
                Tools = {
                    new Tool {
                        Type = ToolType.Close,
                        Handler = "App.direct.Element_Basic.Close2();"
                    }
                }
            };

            p.Render(X.Body().Descriptor, RenderMode.RenderTo);

            Layer layer = new Layer(new LayerConfig
            {
                ID = "Layer2",
                ExistingElement = p.Element
            });

            layer.SetVisible(false, false).AlignTo(this.GetCmp<Panel>("Panel1").Element, "tl-bl", new int[] { 0, 5 }).SlideIn("t");

            this.GetCmp<Button>(sender).Disabled = true;

            return this.Direct();
        }

        [DirectMethod]
        public ActionResult Close(string id)
        {
            X.Get(id).SlideOut("l", new FxConfig
            {
                Callback = new JFunction(X.Get(id).ChainOn().Remove().ToScript(), 200)
            });

            this.GetCmp<Button>("Button1").Disabled = false;

            return this.Direct();
        }

        [DirectMethod]
        public ActionResult Close2(string id)
        {
            Element l2 = X.Get("Layer2").ChainOn();
            l2.SlideOut("t", new FxConfig { Callback = new JFunction(l2.Remove().ToScript(), 200) }).Render();

            this.GetCmp<Button>("Button2").Disabled = false;

            return this.Direct();
        }
    }
}
