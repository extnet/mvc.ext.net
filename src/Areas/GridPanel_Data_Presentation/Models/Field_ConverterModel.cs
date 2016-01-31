using System;
using System.Collections;
using System.Collections.Generic;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_Data_Presentation.Field_Converter
{
    public class Company
    {
        public static IEnumerable GetAll()
        {
            return new object[]
            {
                new object[] { "3m Co", 71.72, 0.02, 0.03, "Y" },
                new object[] { "Alcoa Inc", 29.01, 0.42, 1.47, "Y" },
                new object[] { "Altria Group Inc", 83.81, 0.28, 0.34, "N" },
                new object[] { "Wal-Mart Stores, Inc.", 45.45, 0.73, 1.63, "N" }
            };
        }
    }
}