using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_ColumnModel.Ajax_Configuration.Controllers
{
    public class Ajax_ConfigurationController : Controller
    {
        public ActionResult Index()
        {
            return View(Companies.GetAllCompanies());
        }

        public ActionResult ToggleChange(bool pressed)
        {
            Column c = this.GetCmp<Ext.Net.Column>("ChangeColumn");
            c.Hidden = pressed;

            return new DirectResult();
        }

        public ActionResult ChangeHeader()
        {
            Column c = this.GetCmp<Ext.Net.Column>("CompanyColumn");
            c.Text = "New label";

            return new DirectResult();
        }

        public ActionResult ChangeWidth()
        {
            Column c = this.GetCmp<Ext.Net.Column>("PriceColumn");
            c.Width = 75;

            return new DirectResult();
        }

        public ActionResult ChangeRenderer()
        {
            Column c = this.GetCmp<Ext.Net.Column>("ChangeColumn");
            Renderer r = new Renderer();
            r.Fn = "change";
            c.Renderer = r;

            return new DirectResult();
        }

        public ActionResult AddColumn()
        {
            Store store = this.GetCmp<Store>("Store1");
            Ext.Net.GridPanel grid = this.GetCmp<Ext.Net.GridPanel>("GridPanel1");

            ModelField field = new ModelField("pctChange", ModelFieldType.Float);

            store.AddField(field, 3);

            store.LoadData(Companies.GetAllCompanies());

            Column col = new Column();
            col.ID = "pctChangeColumn";
            col.Text = "Change %";
            col.Width = 75;
            col.Sortable = true;
            col.DataIndex = "pctChange";
            col.Renderer.Fn = "pctChange";

            ComboBox cb = new ComboBox() { ID = "ComboBox1" };
            cb.Items.Add(new Ext.Net.ListItem("1", "1"));
            cb.Items.Add(new Ext.Net.ListItem("2", "2"));
            cb.Items.Add(new Ext.Net.ListItem("3", "3"));

            col.Editor.Add(cb);

            grid.AddColumn(col);

            return this.Direct();
        }

        public ActionResult InsertColumn()
        {
            Ext.Net.GridPanel grid = this.GetCmp<Ext.Net.GridPanel>("GridPanel1");

            DateColumn col = new DateColumn
            {
                Text = "Last Updated",
                Width = 85,
                Sortable = true,
                DataIndex = "lastChange",
                Format = "M/d/yyyy"
            };

            grid.InsertColumn(1, col);

            return this.Direct();
        }

        public ActionResult SetNewPattern()
        {
            this.GetCmp<Column>("CompanyColumn").Pattern = "{value:ellipsis(20)}";
            this.GetCmp<Ext.Net.GridPanel>("GridPanel1").Refresh();

            return this.Direct();
        }
    }
}
