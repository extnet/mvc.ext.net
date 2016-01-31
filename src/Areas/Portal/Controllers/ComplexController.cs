using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Portal.Controllers
{
    using Data = Ext.Net.MVC.Examples.Areas.Portal.Models.Data;

    public class ComplexController : Controller
    {
        public ActionResult Index()
        {
            return View(Data.GetAllCompanies());
        }

        public ActionResult GetCompanies()
        {
            return this.Direct(Data.GetAllCompanies());
        }

        public ActionResult GetPersons()
        {
            return this.Direct(Data.GetAllPersons());
        }

        public ActionResult GetChartData()
        {
            return this.Direct(Data.GetChartData());
        }
    }
}
