using System;
using System.Collections;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_Commands.Cell_Command
{
    public class Companies
    {
        public static IEnumerable GetAllCompanies()
        {
            return new object[]
            {
                new object[] { "3m Co", 71.72, 0.02, 0.03},
                new object[] { "Alcoa Inc", 29.01, 0.42, 1.47},
                new object[] { "Altria Group Inc", 83.81, 0.28, 0.34},
                new object[] { "American Express Company", 52.55, 0.01, 0.02},
                new object[] { "American International Group, Inc.", 64.13, 0.31, 0.49},
                new object[] { "AT&T Inc.", 31.61, -0.48, -1.54},
                new object[] { "Boeing Co.", 75.43, 0.53, 0.71},
                new object[] { "Caterpillar Inc.", 67.27, 0.92, 1.39},
                new object[] { "Citigroup, Inc.", 49.37, 0.02, 0.04},
                new object[] { "E.I. du Pont de Nemours and Company", 40.48, 0.51, 1.28}
            };
        }
    }
}