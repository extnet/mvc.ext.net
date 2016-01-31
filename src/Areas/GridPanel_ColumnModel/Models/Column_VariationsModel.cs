using System;
using System.Collections;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_ColumnModel.Column_Variations
{
    public class Data
    {
        public static IEnumerable GetData()
        {
            return new object[]
            {
                new object[] { true, DateTime.Now, 1 },
                new object[] { false, DateTime.Now.AddDays(-1), 2 },
                new object[] { true, DateTime.Now.AddDays(-2), 3 },
                new object[] { false, DateTime.Now.AddDays(-3), 4 },
                new object[] { true, DateTime.Now.AddDays(-4), 5 }
            };
        }
    }
}