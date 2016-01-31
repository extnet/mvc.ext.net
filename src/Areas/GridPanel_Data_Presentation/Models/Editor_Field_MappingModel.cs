using System;
using System.Collections;
using System.Collections.Generic;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_Data_Presentation.Editor_Field_Mapping
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Department Department { get; set; }

        public int DepartmentId
        {
            get { return this.Department != null ? this.Department.ID : -1; }
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
                                   Department = Department.GetAll()[0]
                               },
                           new Employee
                               {
                                   ID = 2,
                                   Name = "Andrew",
                                   Surname = "Fuller",
                                   Department = Department.GetAll()[2]
                               }
                       };
        }
    }

    public class Department
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public static List<Department> GetAll()
        {
            return new List<Department>
                       {
                           new Department {ID = 1, Name = "Department A"},
                           new Department {ID = 2, Name = "Department B"},
                           new Department {ID = 3, Name = "Department C"}
                       };
        }
    }
}