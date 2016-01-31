using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_Data_Presentation.Field_Converter.Controllers
{
    public class Field_ConverterController : Controller
    {
        public ActionResult Index()
        {
            return View(Company.GetAll());
        }
    }
}
