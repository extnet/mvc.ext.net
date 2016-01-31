using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Form_ComboBox.Linked_Combos_In_Grid.Controllers
{
    public class Linked_Combos_In_GridController : Controller
    {
        public ActionResult Index()
        {
            List<object> countries = new List<object>(10);
            for (int i = 1; i <= 10; i++)
            {
                countries.Add(new { Text = "C" + i });
            }

            return View(new IEnumerable<object>[]
            {
                new List<object>
                {
                    new {Country = "C1", State = "C1_S1", City = "C1_S1_C1", Region = "C1_S1_C1_R1"},
                    new {Country = "C2", State = "C2_S1", City = "C2_S1_C1", Region = "C2_S1_C1_R1"},
                    new {Country = "C3", State = "C3_S1", City = "C3_S1_C1", Region = "C3_S1_C1_R1"},
                },
                countries
            });
        }

        public ActionResult GetStates(string query)
        {
            List<object> states = new List<object>(10);
            for (int i = 1; i <= 10; i++)
            {
                states.Add(new { Text = query + "_S" + i });
            }

            return this.Store(states);
        }

        public ActionResult GetCities(string query)
        {
            List<object> cities = new List<object>(10);
            for (int i = 1; i <= 10; i++)
            {
                cities.Add(new { Text = query + "_C" + i });
            }

            return this.Store(cities);
        }

        public ActionResult GetRegions(string query)
        {
            List<object> regions = new List<object>(10);
            for (int i = 1; i <= 10; i++)
            {
                regions.Add(new { Text = query + "_R" + i });
            }

            return this.Store(regions);
        }

        public ActionResult Edit(string field, string recordData, int index)
        {
            List<string> fields = new List<string> { "country", "state", "city", "region" };
            int startIndex = fields.IndexOf(field);
            JsonObject data = JSON.Deserialize<JsonObject>(recordData);
            ModelProxy record = X.GetCmp<Store>("Store1").GetAt(index);

            for (int i = startIndex + 1; i < 4; i++)
            {
                switch (fields[i])
                {
                    case "state":
                        record.Set(fields[i], data["country"] + "_S1");
                        data["state"] = data["country"] + "_S1";
                        break;
                    case "city":
                        record.Set(fields[i], data["state"] + "_C1");
                        data["city"] = data["state"] + "_C1";
                        break;
                    case "region":
                        record.Set(fields[i], data["city"] + "_R1");
                        break;
                }
            }

            return this.Direct();
        }
    }
}
