using System;
using System.Collections;
using System.Collections.Generic;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_Infinite_Scrolling.Models
{
    public class StockQuotation
    {
        public string Company { get; set; }
        public int Price { get; set; }
        public DateTime LastUpdate { get; set; }

        public static IEnumerable GetStockQuotations(int start, int limit)
        {
            List<StockQuotation> data = new List<StockQuotation>();

            Random randow = new Random();
            DateTime now = DateTime.Now;

            for (int i = start + 1; i <= start + limit; i++)
            {
                StockQuotation qoute = new StockQuotation()
                {
                    Company = "Company " + i,
                    Price = randow.Next(0, 200),
                    LastUpdate = now
                };

                data.Add(qoute);
            }

            return data;
        }
    }
}