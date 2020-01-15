using Ext.Net.MVC.Examples.Areas.Buttons_Basic.Models.VariationsModel;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.UI.HtmlControls;

namespace Ext.Net.MVC.Examples.Areas.Buttons_Basic.Controllers
{
    public class VariationsController : Controller
    {
        public ActionResult Index()
        {
            List<ButtonConfig> configs = new List<ButtonConfig> {
                new ButtonConfig{
                    Name = "Text Only"
                },

                new ButtonConfig{
                    Name = "Disabled",
                    Config = new Ext.Net.Button.Config {
                        Disabled = true
                    }
                },

                new ButtonConfig{
                    Name = "Icon Only",
                    Config = new Ext.Net.Button.Config {
                        IconCls = "add"
                    }
                },

                new ButtonConfig{
                    Name = "Icon (left) and Text",
                    Config = new Ext.Net.Button.Config {
                        IconCls = "add",
                        IconAlign = IconAlign.Left
                    }
                },

                new ButtonConfig{
                    Name = "Icon (top) and Text",
                    Config = new Ext.Net.Button.Config {
                        IconCls = "add",
                        IconAlign = IconAlign.Top
                    }
                },

                new ButtonConfig{
                    Name = "Icon (right) and Text",
                    Config = new Ext.Net.Button.Config {
                        IconCls = "add",
                        IconAlign = IconAlign.Right
                    }
                },

                new ButtonConfig{
                    Name = "Icon (bottom) and Text",
                    Config = new Ext.Net.Button.Config {
                        IconCls = "add",
                        IconAlign = IconAlign.Bottom
                    }
                }
            };

            this.RenderButtons("Normal Buttons", configs, new Ext.Net.Button.Config { CtCls = "floater" });

            this.RenderButtons("Toggle Buttons", configs, new Ext.Net.Button.Config { Cls = "floater", EnableToggle = true });

            this.RenderButtons("Menu Buttons", configs, new Ext.Net.Button.Config { Cls = "floater" }, typeof(Ext.Net.Button), true);

            this.RenderButtons("Split Buttons", configs, new Ext.Net.Button.Config { Cls = "floater" }, typeof(Ext.Net.SplitButton), true);

            this.RenderButtons("Menu Buttons (Arrow on bottom)", configs, new Ext.Net.Button.Config { Cls = "floater", ArrowAlign = ArrowAlign.Bottom }, typeof(Ext.Net.Button), true);

            this.RenderButtons("Split Buttons (Arrow on bottom)", configs, new Ext.Net.Button.Config { Cls = "floater", ArrowAlign = ArrowAlign.Bottom }, typeof(Ext.Net.SplitButton), true);

            this.RenderButtons("Text align: left", configs, new Ext.Net.Button.Config { Cls = "floater", TextAlign = Ext.Net.ButtonTextAlign.Left, Width = 200 });

            this.RenderButtons("Text align: right", configs, new Ext.Net.Button.Config { Cls = "floater", TextAlign = Ext.Net.ButtonTextAlign.Right, Width = 200 });

            this.RenderButtons("Href Buttons", configs, new Ext.Net.Button.Config { Cls = "floater", Href = "https://ext.net/" });

            return View();
        }

        private MenuBase GetMenu()
        {
            return new Ext.Net.Menu
            {
                Items = {
            new Ext.Net.MenuItem("Menu Item 1"),
            new Ext.Net.MenuItem("Menu Item 2"),
            new Ext.Net.MenuItem("Menu Item 3")
        }
            };
        }

        private void RenderButtons(string title, List<ButtonConfig> configs, Ext.Net.Button.Config defaultConfig, Type buttonType = null, bool menu = false)
        {
            var buttons = this.GetCmp<Component>("Buttons");

            buttons.Controls.Add(new HtmlGenericControl
            {
                TagName = "h2",
                InnerText = title
            });

            foreach (ButtonConfig config in configs)
            {
                buttons.Controls.Add(new HtmlGenericControl
                {
                    TagName = "h3",
                    InnerText = config.Name
                });

                HtmlGenericControl div = new HtmlGenericControl
                {
                    TagName = "div"
                };

                buttons.Controls.Add(div);

                foreach (ButtonScale scale in new ButtonScale[] { ButtonScale.Large, ButtonScale.Medium, ButtonScale.Small })
                {
                    ButtonBase button = (ButtonBase)Activator.CreateInstance(buttonType ?? typeof(Ext.Net.Button));

                    if (config.Name != "Icon Only")
                    {
                        button.Text = scale.ToString();
                    }

                    button.Scale = scale;

                    if (config.Config != null)
                    {
                        Ext.Net.Utilities.ObjectUtils.Apply(button, config.Config);
                    }

                    if (defaultConfig != null)
                    {
                        Ext.Net.Utilities.ObjectUtils.Apply(button, defaultConfig);
                    }

                    if (menu)
                    {
                        button.Menu.Add(this.GetMenu());
                    }

                    div.Controls.Add(button);
                }

                div.Controls.Add(new HtmlGenericControl
                {
                    TagName = "div",
                    Style = {
                    Value = "clear: both;"
                }
                });
            }

            X.AddScript(buttons.ToScript());
        }
    }
}
