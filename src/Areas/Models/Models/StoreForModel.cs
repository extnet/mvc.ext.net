using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ext.Net.MVC.Examples.Areas.Models
{
    [Proxy(Read="~/Models/StoreFor/GetEmployees")]
    [JsonReader(RootProperty = "data")]
    [VirtualModelField(Name="FullName", ConvertHandler="fullNameBuilder")]
    [ClientResource(Path="~/Areas/Models/Content/storeHelpers.js")]
    public class Employee
    {
        [ModelField(IDProperty=true)]
        public int Id
        {
            get;
            set;
        }

        public string FirstName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        [ModelField(Ignore=true)]
        public string IgnoreField
        {
            get;
            set;
        }

        public static List<Employee> GetAll()
        {
            return new List<Employee> {
                new Employee{ Id = 1, FirstName = "John", LastName = "Snow"},
                new Employee{ Id = 2, FirstName = "Fred", LastName = "Flintstone"},
                new Employee{ Id = 3, FirstName = "Andrew", LastName = "Fuller"}
            };
        }
    }
}