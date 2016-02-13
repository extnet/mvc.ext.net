using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;
using Ext.Net;

[assembly: WebResource("Ext.Net.MVC.Examples.Areas.DataView_Advanced.Content.Multi_sort.sortbutton.css", "text/css", PerformSubstitution = true)]
[assembly: WebResource("Ext.Net.MVC.Examples.Areas.DataView_Advanced.Content.Multi_sort.SortButton.js", "text/javascript")]
namespace Ext.Net.MVC.Examples.Areas.DataView_Advanced.Models
{
    public class SortButton : Button
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }

        public override string InstanceOf
        {
            get
            {
                return "Ext.multisort.SortButton";
            }
        }

        public override string XType
        {
            get
            {
                return "sortbutton";
            }
        }

        protected override System.Collections.Generic.List<ResourceItem> Resources
        {
            get
            {
                List<ResourceItem> resources = base.Resources;
                resources.Capacity += 2;

                resources.Add(new ClientStyleItem(typeof(SortButton), "Ext.Net.MVC.Examples.Areas.DataView_Advanced.Content.Multi_sort.sortbutton.css", ""));
                resources.Add(new ClientScriptItem(typeof(SortButton), "Ext.Net.MVC.Examples.Areas.DataView_Advanced.Content.Multi_sort.SortButton.js", ""));

                return resources;
            }
        }

        private string dataIndex;

        public string DataIndex {
            get
            {
                object obj = this.dataIndex;
                return obj == null ? "" : obj.ToString();
            }
            set
            {
                this.dataIndex = value;
            }
        }

        public override ConfigOptionsCollection ConfigOptions
        {
            get
            {
                ConfigOptionsCollection config = base.ConfigOptions;
                config.Add("dataIndex", new ConfigOption("dataIndex", new SerializationOptions(JsonMode.Serialize), "", this.DataIndex));
                return config;
            }
        }
    }
}