using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using Ext.Net.MVC.Examples.Areas.PropertyGrid_Basic.Models;
using Newtonsoft.Json;

namespace Ext.Net.MVC.Examples.Areas.PropertyGrid_Basic.Controllers
{
    public class OverviewController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Button1_Click(string rawSourceValues)
        {
            List<StoreValueModel> sourceValues = JsonConvert.DeserializeObject<List<StoreValueModel>>(rawSourceValues);

            //PropertyGrid1.Source contains changed data
            //you can handle this data: read, save and etc

            StringBuilder html = new StringBuilder();
            html.Append("<table class=\"data\">");
            html.Append("<tr><th>Name</th><th>Value</th></tr>");

            // Loop through all PropertyGridParameters and reference by Index.

            foreach (StoreValueModel param in sourceValues)
            {
                html.Append("<tr>");
                html.Append("<td>" + param.name + "</td>");
                html.Append("<td>" + param.value + "</td>");
                html.Append("</tr>");
            }
            html.Append("</table>");

            this.GetCmp<Label>("Label1").Html = html.ToString();

            // Data can be referenced by the PropertyGridParameter
            // "Name" value as well.
            // string name = this.PropertyGrid1.Source["(name)"].Value;
            return this.Direct();
        }

        public ActionResult AddPropertyClick()
        {
            this.GetCmp<PropertyGrid>("PropertyGrid1").AddProperty(new PropertyGridParameter
            {
                Name = "dynProp1",
                Value = "DynamicValue",
                DisplayName = "Dynamic Property",
                Renderer =
                {
                    Handler = "metadata.tdCls = 'red-label'; return value;"
                },
                Editor =
                {
                    new TextField
                    {
                       Triggers =
                       {
                          new FieldTrigger
                          {
                             Icon = TriggerIcon.SimpleEllipsis,
                             Tag = "ellipsis"
                          }
                       },

                       Listeners =
                       {
                          TriggerClick = {
                              Handler = this.GetCmp<PropertyGrid>("PropertyGrid1").ClientID + ".editingPlugin.completeEdit(); Ext.Msg.alert('Trigger click', tag + ' trigger click');"
                          }
                       }
                    }
                }
            });

            return this.Direct();
        }

        public ActionResult RemovePropertyClick()
        {
            this.GetCmp<PropertyGrid>("PropertyGrid1").RemoveProperty("dynProp1");

            return this.Direct();
        }
    }
}
