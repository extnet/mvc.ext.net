using System;
using System.Collections;
using System.Collections.Generic;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_Selection_Models.Models
{
    public class Company
    {
        public Company(int id, string name, double price, double change, double pctChange)
        {
            this.ID = id;
            this.Name = name;
            this.Price = price;
            this.Change = change;
            this.PctChange = pctChange;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double Change { get; set; }
        public double PctChange { get; set; }
    }

    public class Checkbox_SelectionModel
    {
        public IEnumerable Companies
        {
            get
            {
                DateTime now = DateTime.Now;

                return new List<Company>
                {
                    new Company(0, "3m Co", 71.72, 0.02, 0.03),
                    new Company(1, "Alcoa Inc", 29.01, 0.42, 1.47),
                    new Company(2, "Altria Group Inc", 83.81, 0.28, 0.34),
                    new Company(3, "American Express Company", 52.55, 0.01, 0.02),
                    new Company(4, "American International Group, Inc.", 64.13, 0.31, 0.49),
                    new Company(5, "AT&T Inc.", 31.61, -0.48, -1.54),
                    new Company(6, "Boeing Co.", 75.43, 0.53, 0.71),
                    new Company(7, "Caterpillar Inc.", 67.27, 0.92, 1.39),
                    new Company(8, "Citigroup, Inc.", 49.37, 0.02, 0.04),
                    new Company(9, "E.I. du Pont de Nemours and Company", 40.48, 0.51, 1.28),
                    new Company(10, "Exxon Mobil Corp", 68.1, -0.43, -0.64),
                    new Company(11, "General Electric Company", 34.14, -0.08, -0.23),
                    new Company(12, "General Motors Corporation", 30.27, 1.09, 3.74),
                    new Company(13, "Hewlett-Packard Co.", 36.53, -0.03, -0.08),
                    new Company(14, "Honeywell Intl Inc", 38.77, 0.05, 0.13),
                    new Company(15, "Intel Corporation", 19.88, 0.31, 1.58),
                    new Company(16, "International Business Machines", 81.41, 0.44, 0.54),
                    new Company(17, "Johnson & Johnson", 64.72, 0.06, 0.09),
                    new Company(18, "JP Morgan & Chase & Co", 45.73, 0.07, 0.15),
                    new Company(19, "McDonald\"s Corporation", 36.76, 0.86, 2.40),
                    new Company(20, "Merck & Co., Inc.", 40.96, 0.41, 1.01),
                    new Company(21, "Microsoft Corporation", 25.84, 0.14, 0.54),
                    new Company(22, "Pfizer Inc", 27.96, 0.4, 1.45),
                    new Company(23, "The Coca-Cola Company", 45.07, 0.26, 0.58),
                    new Company(24, "The Home Depot, Inc.", 34.64, 0.35, 1.02),
                    new Company(25, "The Procter & Gamble Company", 61.91, 0.01, 0.02),
                    new Company(26, "United Technologies Corporation", 63.26, 0.55, 0.88),
                    new Company(27, "Verizon Communications", 35.57, 0.39, 1.11),
                    new Company(28, "Wal-Mart Stores, Inc.", 45.45, 0.73, 1.63)
                };
            }
        }

        public SelectedRowCollection InitiallySelectedRows
        {
            get
            {
                return new SelectedRowCollection()
                {
                    new SelectedRow(2),
                    new SelectedRow("11")
                };
            }
        }
    }
}