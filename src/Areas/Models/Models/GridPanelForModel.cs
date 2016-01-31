using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ext.Net.MVC.Examples.Areas.Models
{
    public class GridEmployee
    {
        [ModelField(IDProperty=true)]
        [Column(Order=1)]
        public int Id
        {
            get;
            set;
        }

        [Column(Order = 2)]
        public string FirstName
        {
            get;
            set;
        }

        [Column(Order = 3)]
        public string LastName
        {
            get;
            set;
        }

        public static List<GridEmployee> GetAll()
        {
            return new List<GridEmployee> { 
                new GridEmployee{ Id = 1, FirstName = "John", LastName = "Snow"},
                new GridEmployee{ Id = 2, FirstName = "Fred", LastName = "Flintstone"},
                new GridEmployee{ Id = 3, FirstName = "Andrew", LastName = "Fuller"}
            };
        }
    }
}