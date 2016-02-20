using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Form_Login.Auto_Complete.Controllers
{
    public class Auto_CompleteController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Button1_Click(string user, string pass)
        {
            DirectResult r = new DirectResult();

            // Do some Authentication...
            if (user != "Ext.NET" || pass != "extnet")
            {
                r.Success = false;
                r.ErrorMessage = "Invalid username or password.";
            }

            return r;
        }
    }
}
