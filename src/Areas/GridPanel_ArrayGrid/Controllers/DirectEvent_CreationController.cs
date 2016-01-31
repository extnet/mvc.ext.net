using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ext.Net;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_ArrayGrid.DirectEvent_Creation.Controllers
{
    public class DirectEvent_CreationController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetGridPanel(string containerId)
        {
            this.BuildGridPanel().AddTo(containerId);

            return this.Direct();
        }

        private Ext.Net.GridPanel BuildGridPanel()
        {
            return new Ext.Net.GridPanel
            {
                Border = false,
                Store =  
                {
                    this.BuildStore()
                },
                SelectionModel = 
                { 
                    new RowSelectionModel() { Mode = SelectionMode.Single }
                },
                ColumnModel =
                {
                    Columns =
                    {
                        new Column 
                        {
                            Text = "Company", 
                            DataIndex = "company",
                            Flex = 1
                        },
                        new Column
                        {
                            Text = "Price",
                            DataIndex = "price",
                            Renderer = { Format = RendererFormat.UsMoney }
                        },
                        new Column
                        {
                            Text = "Change",
                            DataIndex = "change",
                            Renderer = { Fn = "change" }
                        },
                        new Column
                        {
                            Text = "Change",
                            DataIndex = "pctChange",
                            Renderer = { Fn = "pctChange" }
                        },
                        new DateColumn
                        {
                            Text = "Last Updated",
                            DataIndex = "lastChange"
                        }
                    }
                },
                View =
                {
                   new Ext.Net.GridView()
                   {
                        StripeRows = true,
                        TrackOver = true 
                   }
                }
            };
        }

        private Store BuildStore()
        {
            Store store = new Store
            {
                Model = 
                { 
                    new Model 
                    {
                        Fields = 
                        {
                            new ModelField("company"),
                            new ModelField("price", ModelFieldType.Float),
                            new ModelField("change", ModelFieldType.Float),
                            new ModelField("pctChange", ModelFieldType.Float),
                            new ModelField("lastChange", ModelFieldType.Date, "M/d hh:mmtt")
                        }
                    }
                }
            };

            store.DataSource = Companies.GetAllCompanies();

            return store;
        }
    }
}
