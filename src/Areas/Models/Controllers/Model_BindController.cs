using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Models.Controllers
{
    public class Model_BindController : Controller
    {
        public ActionResult Index()
        {
            return View(new Model_BindModel {
                TextValue = "TextValue",
                DateTimeValue = DateTime.Now,
                ComboValue1 = new ListItem("Item 1", "1"),
                ComboValue2 = new ListItem[] {
                    new ListItem("Item 1", "1"),
                    new ListItem("Item 5", "5")
                },
                ComboValue3 = "1",
                CheckboxValue = true,
                NumberValue = 1,
                MultiSliderValue = new int[] { 10, 40, 70 },

                Data = new ListItem[] {
                    new ListItem("Item 1", "1"),
                    new ListItem("Item 2", "2"),
                    new ListItem("Item 3", "3"),
                    new ListItem("Item 4", "4"),
                    new ListItem("Item 5", "5")
                }
            });
        }
    }
}
