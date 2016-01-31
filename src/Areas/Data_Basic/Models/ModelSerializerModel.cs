using System;
using System.Collections.Generic;

namespace Ext.Net.MVC.Examples.Areas.Data_Basic.Models
{
    public class ModelSerializerModel
    {
        public static Model GetFullModel()
        {
            return new Model()
            {
                Fields =
                {
                    new ModelField("Id", ModelFieldType.Int),
                    new ModelField("Company", ModelFieldType.String),
                    new ModelField("Price", ModelFieldType.Float),
                    new ModelField("Date", ModelFieldType.Date),
                    new ModelField("Size", ModelFieldType.String),
                    new ModelField("Visible", ModelFieldType.Boolean)
                }
            };
        }

        public static List<object> Data
        {
            get
            {
                List<object> goods = new List<object>()
                {
                    new
                        {
                            Id = 1,
                            Price = 71.72,
                            Company = "3m Co",
                            Date = new DateTime(2013, 9, 1),
                            Size = "large",
                            Visible = true
                        },
                    new
                        {
                            Id = 2,
                            Price = 29.01,
                            Company = "Aloca Inc",
                            Date = new DateTime(2013, 08, 01),
                            Size = "medium",
                            Visible = false
                        },
                    new
                        {
                            Id = 3,
                            Price = 83.81,
                            Company = "Altria Group Inc",
                            Date = new DateTime(2013, 08, 03),
                            Size = "large",
                            Visible = false
                        },
                    new
                        {
                            Id = 4,
                            Price = 52.55,
                            Company = "American Express Company",
                            Date = new DateTime(2014, 01, 04),
                            Size = "extra large",
                            Visible = true
                        },
                    new
                        {
                            Id = 5,
                            Price = 64.13,
                            Company = "American International Group Inc.",
                            Date = new DateTime(2014, 03, 04),
                            Size = "small",
                            Visible = true
                        },
                    new
                        {
                            Id = 6,
                            Price = 31.61,
                            Company = "AT&T Inc.",
                            Date = new DateTime(2014, 02, 01),
                            Size = "extra large",
                            Visible = false
                        },
                    new
                        {
                            Id = 7,
                            Price = 75.43,
                            Company = "Boeing Co.",
                            Date = new DateTime(2014, 01, 01),
                            Size = "large",
                            Visible = true
                        }
                };

                return goods;
            }
        }
    }
}