using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Ext.Net.MVC.Examples.Areas.Models.Models
{
    public class FormPanelEmployee
    {
        [Field(FieldType=typeof(Ext.Net.Hidden))]
        public int ID { get; set; }
        
        public string Name { get; set; }
        public string Surname { get; set; }

        public DateTime DateOfBirth { get; set; }

        public bool IsActive { get; set; }

        [UIHint("Department")]
        public FormPanelDepartment Department { get; set; }

        public static List<FormPanelEmployee> GetAll()
        {
            return new List<FormPanelEmployee>
            {
               new FormPanelEmployee
               {
                   ID = 1,
                   Name = "Nancy",
                   Surname = "Davolio",
                   DateOfBirth = DateTime.Now,
                   IsActive = true,
                   Department = FormPanelDepartment.GetAll()[0]
               },
               new FormPanelEmployee
               {
                   ID = 2,
                   Name = "Andrew",
                   Surname = "Fuller",
                   Department = FormPanelDepartment.GetAll()[2]
               }
            };
        }
    }

    public class FormPanelDepartment
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public static List<FormPanelDepartment> GetAll()
        {
            return new List<FormPanelDepartment>
            {
                new FormPanelDepartment { ID = 1, Name = "Department A" },
                new FormPanelDepartment { ID = 2, Name = "Department B" },
                new FormPanelDepartment { ID = 3, Name = "Department C" }
            };
        }
    }
}