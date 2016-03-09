using System;
using System.Collections.Generic;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_Spreadsheet.Models
{
    public class GridPanel_SpreadsheetOverviewModel
    {
        public static List<object> GetData()
        {
            var data = new List<object>();
            var thisYear = DateTime.Today.Year;
            var random = new Random();

            for (int year = 1900; year <= thisYear; ++year)
            {
                data.Add(new object[]
                {
                    year,
                    GridPanel_SpreadsheetOverviewModel.GetRandomNumber(-10, 100, random),
                    GridPanel_SpreadsheetOverviewModel.GetRandomNumber(-10, 100, random),
                    GridPanel_SpreadsheetOverviewModel.GetRandomNumber(-10, 200, random),
                    GridPanel_SpreadsheetOverviewModel.GetRandomNumber(-10, 200, random),
                    GridPanel_SpreadsheetOverviewModel.GetRandomNumber(-10, 200, random),
                    GridPanel_SpreadsheetOverviewModel.GetRandomNumber(-10, 300, random),
                    GridPanel_SpreadsheetOverviewModel.GetRandomNumber(-10, 300, random),
                    GridPanel_SpreadsheetOverviewModel.GetRandomNumber(-10, 300, random),
                    GridPanel_SpreadsheetOverviewModel.GetRandomNumber(-10, 600, random),
                    GridPanel_SpreadsheetOverviewModel.GetRandomNumber(-10, 500, random),
                    GridPanel_SpreadsheetOverviewModel.GetRandomNumber(-10, 200, random),
                    GridPanel_SpreadsheetOverviewModel.GetRandomNumber(-10, 100, random)
                });
            }

            return data;
        }

        public static int GetRandomNumber(int min, int max, Random r)
        {
            return (int)Math.Floor(r.NextDouble() * (max - min)) + min;
        }
    }
}