using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_Plugins.Models
{
    public class GridFiltersModel
    {
        public static List<object> Data
        {
            get
            {
                List<object> goods = new List<object>
                {
                    new
                    {
                        Id = 1,
                        Price = 71.72,
                        Company = "3m Co",
                        Date = new DateTime(2014, 9, 1),
                        Size = "large",
                        Visible = true
                    },
                    new
                    {
                        Id = 2,
                        Price = 29.01,
                        Company = "Aloca Inc",
                        Date = new DateTime(2014, 08, 01),
                        Size = "medium",
                        Visible = false
                    },
                    new
                    {
                        Id = 3,
                        Price = 83.81,
                        Company = "Altria Group Inc",
                        Date = new DateTime(2014, 08, 03),
                        Size = "large",
                        Visible = false
                    },
                    new
                    {
                        Id = 4,
                        Price = 52.55,
                        Company = "American Express Company",
                        Date = new DateTime(2015, 01, 04),
                        Size = "extra large",
                        Visible = true
                    },
                    new
                    {
                        Id = 5,
                        Price = 64.13,
                        Company = "American International Group Inc.",
                        Date = new DateTime(2015, 03, 04),
                        Size = "small",
                        Visible = true
                    },
                    new
                    {
                        Id = 6,
                        Price = 31.61,
                        Company = "AT&T Inc.",
                        Date = new DateTime(2015, 02, 01),
                        Size = "extra large",
                        Visible = false
                    },
                    new
                    {
                        Id = 7,
                        Price = 75.43,
                        Company = "Boeing Co.",
                        Date = new DateTime(2015, 01, 01),
                        Size = "large",
                        Visible = true
                    },
                    new
                    {
                        Id = 8,
                        Price = 67.27,
                        Company = "Caterpillar Inc.",
                        Date = new DateTime(2014, 12, 03),
                        Size = "medium",
                        Visible = true
                    },
                    new
                    {
                        Id = 9,
                        Price = 49.37,
                        Company = "Citigroup, Inc.",
                        Date = new DateTime(2014, 11, 24),
                        Size = "large",
                        Visible = true
                    },
                    new
                    {
                        Id = 10,
                        Price = 40.48,
                        Company = "E.I. du Pont de Nemours and Company",
                        Date = new DateTime(2014, 05, 09),
                        Size = "extra large",
                        Visible = false
                    },
                    new
                    {
                        Id = 11,
                        Price = 68.1,
                        Company = "Exxon Mobile Corp",
                        Date = new DateTime(2014, 12, 12),
                        Size = "large",
                        Visible = true
                    },
                    new
                    {
                        Id = 12,
                        Price = 34.14,
                        Company = "General Electric Company",
                        Date = new DateTime(2015, 06, 16),
                        Size = "extra large",
                        Visible = true
                    },
                    new
                    {
                        Id = 13,
                        Price = 30.27,
                        Company = "General Motors Corporation",
                        Date = new DateTime(2013, 12, 07),
                        Size = "medium",
                        Visible = true
                    },
                    new
                    {
                        Id = 14,
                        Price = 36.53,
                        Company = "Hewlett-Packard Co.",
                        Date = new DateTime(2014, 05, 13),
                        Size = "large",
                        Visible = true
                    },
                    new
                    {
                        Id = 15,
                        Price = 38.77,
                        Company = "Honweywell Intl Inc",
                        Date = new DateTime(2013, 11, 07),
                        Size = "medium",
                        Visible = false
                    },
                    new
                    {
                        Id = 16,
                        Price = 19.88,
                        Company = "Intel Corporation",
                        Date = new DateTime(2014, 01, 09),
                        Size = "small",
                        Visible = true
                    },
                    new
                    {
                        Id = 17,
                        Price = 81.41,
                        Company = "International Business Machines",
                        Date = new DateTime(2012, 01, 21),
                        Size = "extra large",
                        Visible = true
                    },
                    new
                    {
                        Id = 18,
                        Price = 64.72,
                        Company = "Johnson & Johnson",
                        Date = new DateTime(2015, 01, 10),
                        Size = "extra large",
                        Visible = true
                    },
                    new
                    {
                        Id = 19,
                        Price = 45.73,
                        Company = "JP Morgan & Chase & Co",
                        Date = new DateTime(2015, 02, 20),
                        Size = "large",
                        Visible = false
                    },
                    new
                    {
                        Id = 20,
                        Price = 36.76,
                        Company = "McDonald's Corporation",
                        Date = new DateTime(2014, 06, 12),
                        Size = "large",
                        Visible = true
                    },
                    new
                    {
                        Id = 21,
                        Price = 27.96,
                        Company = "Pfizer Inc",
                        Date = new DateTime(2014, 12, 30),
                        Size = "small",
                        Visible = false
                    },
                    new
                    {
                        Id = 22,
                        Price = 45.07,
                        Company = "The Coca-Cola Company",
                        Date = new DateTime(2014, 01, 30),
                        Size = "medium",
                        Visible = false
                    },
                    new
                    {
                        Id = 23,
                        Price = 34.64,
                        Company = "The Home Depot, Inc",
                        Date = new DateTime(2013, 12, 31),
                        Size = "small",
                        Visible = true
                    },
                    new
                    {
                        Id = 24,
                        Price = 61.91,
                        Company = "The Procter & Gamble Company",
                        Date = new DateTime(2014, 04, 08),
                        Size = "extra large",
                        Visible = true
                    },
                    new
                    {
                        Id = 25,
                        Price = 63.26,
                        Company = "United Technologies Corporation",
                        Date = new DateTime(2013, 06, 04),
                        Size = "medium",
                        Visible = true
                    },
                    new
                    {
                        Id = 26,
                        Price = 35.57,
                        Company = "Verizon Communications",
                        Date = new DateTime(2012, 07, 09),
                        Size = "small",
                        Visible = false
                    },
                    new
                    {
                        Id = 27,
                        Price = 45.45,
                        Company = "Wal-Mart Stores, Inc",
                        Date = new DateTime(2013, 09, 09),
                        Size = "large",
                        Visible = true
                    }
                };

                return goods;
            }
        }
    }
}