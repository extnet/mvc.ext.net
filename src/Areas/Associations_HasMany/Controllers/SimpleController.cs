using System.Collections.Generic;
using System.Web.Mvc;
using Ext.Net.MVC.Examples.Areas.Associations_HasMany.Models;

namespace Ext.Net.MVC.Examples.Areas.Associations_HasMany.Controllers
{
    public class SimpleController : Controller
    {
        public ActionResult Index()
        {
            List<User> data = new List<User>
            {
                new User(1, "User1", new List<Product>{
                    new Product(1, "Product1 of User1"),
                    new Product(2, "Product2 of User1"),
                    new Product(3, "Product3 of User1")
                }),

                new User(2, "User2", new List<Product>{
                    new Product(4, "Product1 of User2"),
                    new Product(5, "Product2 of User2"),
                    new Product(6, "Product3 of User2")
                }),

                new User(3, "User3", new List<Product>{
                    new Product(7, "Product1 of User3"),
                    new Product(8, "Product2 of User3"),
                    new Product(9, "Product3 of User3")
                })
            };
            return View(data);
        }
    }
}
