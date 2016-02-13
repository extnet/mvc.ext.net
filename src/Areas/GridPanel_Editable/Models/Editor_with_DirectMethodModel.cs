using System;
using System.Collections;
using System.Collections.Generic;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_Editable.Editor_with_DirectMethod
{
    public class Company
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double Change { get; set; }
        public double PctChange { get; set; }
        public DateTime LastChange { get; set; }

        public static IEnumerable GetAll()
        {
            DateTime today = DateTime.Today;

            return new List<Company>
            {
                new Company { ID = 1, Name = "3m Co", Price = 71.72, Change = 0.02, PctChange = 0.03, LastChange = today },
                new Company { ID = 2, Name = "Alcoa Inc", Price = 29.01, Change = 0.42, PctChange = 1.47, LastChange = today },
                new Company { ID = 3, Name = "Altria Group Inc", Price = 83.81, Change = 0.28, PctChange = 0.34, LastChange = today },
                new Company { ID = 4, Name = "American Express Company", Price = 52.55, Change = 0.01, PctChange = 0.02, LastChange = today },
                new Company { ID = 5, Name = "American International Group, Inc.", Price = 64.13, Change = 0.31, PctChange = 0.49, LastChange = today },
                new Company { ID = 6, Name = "AT&T Inc.", Price = 31.61, Change = -0.48, PctChange = -1.54, LastChange = today },
                new Company { ID = 7, Name = "Boeing Co.", Price = 75.43, Change = 0.53, PctChange = 0.71, LastChange = today },
                new Company { ID = 8, Name = "Caterpillar Inc.", Price = 67.27, Change = 0.92, PctChange = 1.39, LastChange = today },
                new Company { ID = 9, Name = "Citigroup, Inc.", Price = 49.37, Change = 0.02, PctChange = 0.04, LastChange = today },
                new Company { ID = 10, Name = "E.I. du Pont de Nemours and Company", Price = 40.48, Change = 0.51, PctChange = 1.28, LastChange = today },
                new Company { ID = 11, Name = "Exxon Mobil Corp", Price = 68.1, Change = -0.43, PctChange = -0.64, LastChange = today },
                new Company { ID = 12, Name = "General Electric Company", Price = 34.14, Change = -0.08, PctChange = -0.23, LastChange = today },
                new Company { ID = 13, Name = "General Motors Corporation", Price = 30.27, Change = 1.09, PctChange = 3.74, LastChange = today },
                new Company { ID = 14, Name = "Hewlett-Packard Co.", Price = 36.53, Change = -0.03, PctChange = -0.08, LastChange = today },
                new Company { ID = 15, Name = "Honeywell Intl Inc", Price = 38.77, Change = 0.05, PctChange = 0.13, LastChange = today },
                new Company { ID = 16, Name = "Intel Corporation", Price = 19.88, Change = 0.31, PctChange = 1.58, LastChange = today },
                new Company { ID = 17, Name = "International Business Machines", Price = 81.41, Change = 0.44, PctChange = 0.54, LastChange = today },
                new Company { ID = 18, Name = "Johnson & Johnson", Price = 64.72, Change = 0.06, PctChange = 0.09, LastChange = today },
                new Company { ID = 19, Name = "JP Morgan & Chase & Co", Price = 45.73, Change = 0.07, PctChange = 0.15, LastChange = today },
                new Company { ID = 20, Name = "McDonald\"s Corporation", Price = 36.76, Change = 0.86, PctChange = 2.40, LastChange = today },
                new Company { ID = 21, Name = "Merck & Co., Inc.", Price = 40.96, Change = 0.41, PctChange = 1.01, LastChange = today },
                new Company { ID = 22, Name = "Microsoft Corporation", Price = 25.84, Change = 0.14, PctChange = 0.54, LastChange = today },
                new Company { ID = 23, Name = "Pfizer Inc", Price = 27.96, Change = 0.4, PctChange = 1.45, LastChange = today },
                new Company { ID = 24, Name = "The Coca-Cola Company", Price = 45.07, Change = 0.26, PctChange = 0.58, LastChange = today },
                new Company { ID = 25, Name = "The Home Depot, Inc.", Price = 34.64, Change = 0.35, PctChange = 1.02, LastChange = today },
                new Company { ID = 26, Name = "The Procter & Gamble Company", Price = 61.91, Change = 0.01, PctChange = 0.02, LastChange = today },
                new Company { ID = 27, Name = "United Technologies Corporation", Price = 63.26, Change = 0.55, PctChange = 0.88, LastChange = today },
                new Company { ID = 28, Name = "Verizon Communications", Price = 35.57, Change = 0.39, PctChange = 1.11, LastChange = today },
                new Company { ID = 29, Name = "Wal-Mart Stores, Inc.", Price = 45.45, Change = 0.73, PctChange = 1.63, LastChange = today }
            };
        }
    }
}