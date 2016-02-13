using System.Collections.Generic;
using System.Web.Mvc;
using Ext.Net.MVC.Examples.Areas.Associations_HasOne.Models;

namespace Ext.Net.MVC.Examples.Areas.Associations_HasOne.Controllers
{
    public class SimpleController : Controller
    {
        public ActionResult Index()
        {
            List<Person> data = new List<Person>
            {
                new Person(1, "John Smith", new Address(1, "1", "Cross Street 11/1", "Big City", "123456" )),
                new Person(2, "Jane Brown", new Address(2, "2", "Cross Street 12/2", "Big City", "654321" )),
                new Person(3, "Kevin Jones", new Address(3, "3", "Cross Street 13/3", "Big City", "321654" ))
            };
            return View(data);
        }
    }
}
