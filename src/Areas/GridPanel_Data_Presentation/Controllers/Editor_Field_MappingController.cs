using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_Data_Presentation.Editor_Field_Mapping.Controllers
{
    public class Editor_Field_MappingController : Controller
    {
        public ActionResult Index()
        {
            return View(new object[] 
                { 
                    Employee.GetAll(),
                    Department.GetAll()
                });
        }
    }
}
