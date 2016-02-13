using System.Web.Mvc;
using System.Web.UI;

namespace Ext.Net.MVC.Examples.Areas.Element_Basic.Controllers
{
    public class OverviewController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        private void BuildCards()
        {
            // 1. Add required css rules
            CSS.SwapStyleSheet("cards", Url.Content("~/Areas/Element_Basic/Content/styles.css"));

            // 2. Append main Container
            Element topEl = DomHelper.Append(X.Body(), new DomObject { ID = "Cards1", Cls = "cards-container" });

            // 3. Append header Container
            Element header = DomHelper.Append(topEl, new DomObject { Cls = "cards-header" });

            DomHelper.Append(header,
                new DomObject
                {
                    Tag = HtmlTextWriterTag.Ul,
                    Children = {
                     new DomObject {
                         Tag = HtmlTextWriterTag.Li,
                         Children = {
                            new DomObject {
                                Tag = HtmlTextWriterTag.A,
                                Html = "RECENT",
                                CustomConfig = { new ConfigItem("rel", "c0", ParameterMode.Value)}
                            }
                         }
                     },

                     new DomObject {
                         Tag = HtmlTextWriterTag.Li,
                         Children = {
                            new DomObject {
                                Tag = HtmlTextWriterTag.A,
                                Html = "COMMENTS",
                                CustomConfig = { new ConfigItem("rel", "c1", ParameterMode.Value)}
                            }
                         }
                     },

                     new DomObject {
                         Tag = HtmlTextWriterTag.Li,
                         Children = {
                            new DomObject {
                                Tag = HtmlTextWriterTag.A,
                                Html = "POPULAR",
                                CustomConfig = { new ConfigItem("rel", "c2", ParameterMode.Value)}
                            }
                         }
                     },

                     new DomObject {
                         Tag = HtmlTextWriterTag.Li,
                         Children = {
                            new DomObject {
                                Tag = HtmlTextWriterTag.A,
                                Html = "TAGS",
                                CustomConfig = { new ConfigItem("rel", "c3", ParameterMode.Value)}
                            }
                         }
                     }
                }
                }
            );

            // 4. Append Content Container
            Element content = DomHelper.Append(topEl, new DomObject { Cls = "cards-content" });
            Element curCard = DomHelper.Append(content,
                new DomObject
                {
                    Cls = "current-card",
                    Children = {
                   new DomObject { Html = "RECENT", ID = "c0", Cls = "card" },
                   new DomObject { Html = "COMMENTS<br />COMMENTS", ID = "c1", Cls = "card" },
                   new DomObject { Html = "POPULAR<br />POPULAR<br />POPULAR", ID = "c2", Cls = "card" },
                   new DomObject { Html = "TAGS<br />TAGS<br />TAGS<br />TAGS", ID = "c3", Cls = "card" }
                }
                }
            );

            curCard.SetStyle("height", "auto");

            topEl.Chaining = true;

            topEl.Select(".cards-header a", true)
                .Hover(new JFunction { Fn = "hoverCard" }, JFunction.EmptyFn)
                .First()
                .AddCls("current")
                .Render();

            content.Chaining = true;
            content.Select(".card").SetVisibilityMode(VisibilityMode.Display).Hide().First().Show().Render();
        }

        public ActionResult CreateClick()
        {
            this.BuildCards();

            this.GetCmp<Button>("Button1").Disabled = true;

            return this.Direct();
        }
    }
}
