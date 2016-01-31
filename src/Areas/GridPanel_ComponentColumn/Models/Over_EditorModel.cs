using System;
using System.Collections;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_ComponentColumn.Over_Editor
{
    public class TestData
    {
        public static IEnumerable GetData()
        {
            DateTime now = DateTime.Now;

            return new object[]
                {
                    new object[] { 1, 1, "Text 1", DateTime.Now.Date },
                    new object[] { 2, 2, "Text 2", DateTime.Now.Date },
                    new object[] { 3, 3, "Text 3", DateTime.Now.Date },
                    new object[] { 4, 4, "Text 4", DateTime.Now.Date },
                    new object[] { 5, 5, "Text 5", DateTime.Now.Date },
                    new object[] { 6, 6, "Text 6", DateTime.Now.Date },
                    new object[] { 7, 7, "Text 7", DateTime.Now.Date },
                    new object[] { 8, 8, "Text 8", DateTime.Now.Date },
                    new object[] { 9, 9, "Text 9", DateTime.Now.Date }
                };
        }
    }
}