using System;
using System.Collections;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_ComponentColumn.Overview
{
    public class TestData
    {
        public static IEnumerable GetData()
        {
            return new object[]
                {
                    new object[]
                    {
                        new object[] { 1, 0.2 },
                        new object[] { 2, 0.4 },
                        new object[] { 3, 0.6 },
                        new object[] { 4, 0.8 },
                        new object[] { 5, 1.0 }
                    },
                    
                    new object[]
                    {
                        new object[] { 0, "Task 1", 0, 0 },
                        new object[] { 1, "Task 2", 0, 0 },
                        new object[] { 2, "Task 3", 0, 0 },
                        new object[] { 3, "Task 4", 0, 0 },
                        new object[] { 4, "Task 5", 0, 0 }
                    }
                };
        }
    }
}