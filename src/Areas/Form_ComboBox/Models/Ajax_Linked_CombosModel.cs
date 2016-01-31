using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Web;

namespace Ext.Net.MVC.Examples.Areas.Form_ComboBox.Ajax_Linked_Combos.Models
{
    public class City
    {
        public static IEnumerable GetCities(string country)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(HttpContext.Current.Server.MapPath("~/Areas/Form_ComboBox/Content/Cities.xml"));
            List<object> data = new List<object>();

            foreach (XmlNode cityNode in xmlDoc.SelectNodes(string.Concat("countries/country[@code='", country, "']/city")))
            {
                string id = cityNode.SelectSingleNode("id").InnerText;
                string name = cityNode.SelectSingleNode("name").InnerText;

                data.Add(new { Id = id, Name = name });
            }

            return data;
        }
    }
}