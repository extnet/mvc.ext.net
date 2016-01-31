using System;
using System.Collections;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_ColumnModel.RatingColumn
{
    public class Companies
    {
        public static IEnumerable GetCompanies()
        {
            return new object[]
            {
                new object[] { "3m Co", 1, 3, 1 },
                new object[] { "Alcoa Inc", 2, 2.7, 2 },
                new object[] { "Altria Group Inc", 3.5, 2, 3 },
                new object[] { "American Express Company", 4, 1.3, 4 },
                new object[] { "American International Group, Inc.", 5, 0, 5 }
            };
        }
    }
}