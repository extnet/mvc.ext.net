using System;
using System.Collections;
using System.Collections.Generic;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_Data_Presentation.Server_Mapping
{
    public class Department
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string GetIdPlusName()
        {
            return this.ID + ": " + this.Name;
        }

        public static List<Department> GetAll()
        {
            return new List<Department>
            {
                new Department { ID = 1, Name = "Department A" },
                new Department { ID = 2, Name = "Department B" },
                new Department { ID = 3, Name = "Department C" }
            };
        }
    }

    public class Employee
    {
        public int ID { get; set; }
        public string GUID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Department Department { get; set; }
        public string[] Phone { get; set; }

        public string GetFullName()
        {
            return this.Name + " " + this.Surname;
        }

        public static List<Employee> GetAll()
        {
            return new List<Employee>
            {
                new Employee
                {
                    ID = 1,
                    Name = "Nancy",
                    Surname = "Davolio",
                    Department = Department.GetAll()[0],
                    Phone = new string[] { "555-555-555", "777-777-777" }
                },
                new Employee
                {
                    ID = 2,
                    Name = "Andrew",
                    Surname = "Fuller",
                    Department = Department.GetAll()[2],
                    Phone = new string[] { "333-333-333", "111-111-111" }
                }
            };
        }
    }
}