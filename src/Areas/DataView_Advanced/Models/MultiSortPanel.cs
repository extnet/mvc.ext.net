using System;
using System.Collections.Generic;
using System.Web.UI;
using Ext.Net;

[assembly: WebResource("Ext.Net.MVC.Examples.Areas.DataView_Advanced.Content.Multi_sort.multisortpanel.css", "text/css", PerformSubstitution = true)]
[assembly: WebResource("Ext.Net.MVC.Examples.Areas.DataView_Advanced.Content.Multi_sort.MultiSortPanel.js", "text/javascript")]
namespace Ext.Net.MVC.Examples.Areas.DataView_Advanced.Models
{
    public class MultiSortPanel : Panel
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Width = 730;
            this.Height = 535;
            this.Title = "Multisort DataView";
            this.Scrollable = ScrollableOption.Both;
            this.TopBar.Add(this.GetTopBar());
            this.Items.Add(this.GetDataView());
            this.Frame = true;
        }

        public override string InstanceOf
        {
            get
            {
                return "Ext.multisort.Panel";
            }
        }

        public override string XType
        {
            get
            {
                return "multisortpanel";
            }
        }

        protected override List<ResourceItem> Resources
        {
            get
            {
                List<ResourceItem> resources = base.Resources;
                resources.Capacity += 2;

                resources.Add(new ClientStyleItem(typeof(MultiSortPanel), "Ext.Net.MVC.Examples.Areas.DataView_Advanced.Content.Multi_sort.multisortpanel.css", ""));
                resources.Add(new ClientScriptItem(typeof(MultiSortPanel), "Ext.Net.MVC.Examples.Areas.DataView_Advanced.Content.Multi_sort.MultiSortPanel.js", ""));

                return resources;
            }
        }

        private Toolbar GetTopBar()
        {
            Toolbar tb = new Toolbar();
            tb.Plugins.Add(new BoxReorderer()
            {
                Listeners =
                {
                    Drop =
                    {
                        Handler = "var p = container.ownerCt; p.down('dataview').store.sort(p.getSorters());"
                    }
                }
            });

            tb.Items.Add(new ToolbarTextItem()
            {
                Text = "Sort on these fields:",
                CustomConfig =
                    {
                        new ConfigItem("reordable", "false", ParameterMode.Raw)
                    }
            });

            tb.Items.Add(new SortButton()
            {
                Text = "Type",
                DataIndex = "type"
            });

            tb.Items.Add(new SortButton()
            {
                Text = "Name",
                DataIndex = "name"
            });

            return tb;
        }

        private DataView GetDataView()
        {
            DataView view = new DataView()
                {
                    ID = "DataView1"
                };

            XTemplate tpl = new XTemplate()
                {
                    ID = "XTemplate1"
                };
            string path = ExtNetTransformer.ResolveUrl("~/Areas/DataView_Basic/Content/");
            tpl.Html = "<tpl for=\".\">" +
                              "<div class=\"item\">" +
                                  "<tpl if=\"!Ext.isIE6\">" +
                                      "<img src=\"" + path + "images/touch-icons/{thumb}\" />" +
                                  "</tpl>" +
                                  "<tpl if=\"Ext.isIE6\">" +
                                      "<div style=\"position:relative;width:74px;height:74px;filter:progid:DXImageTransform.Microsoft.AlphaImageLoader(src=\"" + path + "images/touch-icons/{thumb}\")></div>" +
                                  "</tpl>" +
                                  "<h3>{name}</h3>" +
                              "</div>" +
                          "</tpl>";

            view.Tpl = tpl;

            view.Plugins.Add(new DataViewAnimated());
            view.ItemSelector = "div.item";
            view.Store.Add(this.GetStore());

            return view;
        }

        private Store GetStore()
        {
            Store store = new Store()
                {
                    ID = "Store1"
                };
            store.SortOnLoad = true;

            Model model = new Model()
                {
                    Fields =
                {
                    new ModelField("name"),
                    new ModelField("thumb"),
                    new ModelField("url"),
                    new ModelField("type")
                }
                };
            store.Model.Add(model);

            AjaxProxy proxy = new AjaxProxy()
                {
                    Url = "~/Areas/DataView_Basic/Content/sencha-touch-examples.json",
                    Reader =
                    {
                        new JsonReader()
                    }
                };

            store.Proxy.Add(proxy);

            return store;
        }
    }
}