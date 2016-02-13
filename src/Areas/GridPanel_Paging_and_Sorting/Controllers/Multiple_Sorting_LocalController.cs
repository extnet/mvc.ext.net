using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_Paging_and_Sorting.Controllers
{
    public class Multiple_Sorting_LocalController : Controller
    {
        private object[] TestData
        {
            get
            {
                string[] firstNames = new string[] { "Russel", "Clark", "Steve", "Sam", "Lance", "Robert", "Sean", "David", "Justin" };
                string[] lastNames = new string[] { "Wood", "Lewis", "Scott", "Parker", "Ross", "Garcia", "Bell", "Kelly", "Powell" };
                int[] ratings = new int[] { 1, 2, 3, 4, 5 };
                int[] salaries = new int[] { 100, 400, 900, 1500, 1000000 };

                object[] data = new object[25];
                Random rnd = new Random();

                for (int i = 0; i < 25; i++)
                {
                    int ratingId = rnd.Next(ratings.Length);
                    int salaryId = rnd.Next(salaries.Length);
                    int firstNameId = rnd.Next(firstNames.Length);
                    int lastNameId = rnd.Next(lastNames.Length);

                    int rating = ratings[ratingId];
                    int salary = salaries[salaryId];
                    string name = String.Format("{0} {1}", firstNames[firstNameId], lastNames[lastNameId]);

                    data[i] = new object[] { name, rating, salary };
                }

                return data;
            }
        }

        public ActionResult Index()
        {
            return View(TestData);
        }
    }
}
