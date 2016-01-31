using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Web;
using System.Globalization;

namespace Ext.Net.MVC.Examples.Areas.Form_ComboBox.Custom_Search.Models
{
    public class Plant
    {
        public Plant(bool indoor, DateTime availability, decimal price, string light, string zone, string botanical, string common)
        {
            this.Indoor = indoor;
            this.Availability = availability;
            this.Price = price;
            this.Light = light;
            this.Zone = zone;
            this.Botanical = botanical;
            this.Common = common;
        }

        public Plant()
        {
        }

        public string Common { get; set; }

        public string Botanical { get; set; }

        public string Zone { get; set; }

        public string Light { get; set; }

        public decimal Price { get; set; }

        public DateTime Availability { get; set; }

        public bool Indoor { get; set; }

        public static Paging<Plant> PlantsPaging(int start, int limit, string sort, string dir, string filter)
        {
            List<Plant> plants = Plant.TestData;

            if (!string.IsNullOrEmpty(filter) && filter != "*")
            {
                plants.RemoveAll(plant => !plant.Common.ToLower().StartsWith(filter.ToLower()));
            }

            if (!string.IsNullOrEmpty(sort))
            {
                plants.Sort(delegate(Plant x, Plant y)
                {
                    object a;
                    object b;

                    int direction = dir == "DESC" ? -1 : 1;

                    a = x.GetType().GetProperty(sort).GetValue(x, null);
                    b = y.GetType().GetProperty(sort).GetValue(y, null);

                    return CaseInsensitiveComparer.Default.Compare(a, b) * direction;
                });
            }

            if ((start + limit) > plants.Count)
            {
                limit = plants.Count - start;
            }

            List<Plant> rangePlants = (start < 0 || limit < 0) ? plants : plants.GetRange(start, limit);

            return new Paging<Plant>(rangePlants, plants.Count);
        }

        public static List<Plant> TestData
        {
            get
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(HttpContext.Current.Server.MapPath("~/Areas/Form_ComboBox/Content/Plants.xml"));
                List<Plant> data = new List<Plant>();
                IFormatProvider culture = new CultureInfo("en-US", true);

                foreach (XmlNode plantNode in xmlDoc.SelectNodes("catalog/plant"))
                {
                    Plant plant = new Plant();

                    plant.Common = plantNode.SelectSingleNode("common").InnerText;
                    plant.Botanical = plantNode.SelectSingleNode("botanical").InnerText;
                    plant.Zone = plantNode.SelectSingleNode("zone").InnerText;
                    plant.Light = plantNode.SelectSingleNode("light").InnerText;
                    plant.Price = decimal.Parse(plantNode.SelectSingleNode("price").InnerText, culture);
                    plant.Availability = DateTime.ParseExact(plantNode.SelectSingleNode("availability").InnerText, "MM/dd/yyyy", culture);
                    plant.Indoor = bool.Parse(plantNode.SelectSingleNode("indoor").InnerText);

                    data.Add(plant);
                }

                return data;
            }
        }
    }
}