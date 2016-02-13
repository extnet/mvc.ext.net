using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Layout_CardLayout.Controllers
{
    public class BasicController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Next_Click(int index)
        {
            if ((index + 1) < 3)
            {
                this.GetCmp<Panel>("WizardPanel").ActiveIndex = index + 1;
                this.CheckButtons(index + 1);
            } else
                this.CheckButtons(index);


            return this.Direct();
        }

        public ActionResult Prev_Click(int index)
        {
            if ((index - 1) >= 0)
            {
                this.GetCmp<Panel>("WizardPanel").ActiveIndex = index - 1;

                this.CheckButtons(index - 1);
            } else
                this.CheckButtons(index);

            return this.Direct();
        }

        private void CheckButtons(int index)
        {
            this.GetCmp<Button>("btnNext").Disabled = index == 2;
            this.GetCmp<Button>("btnPrev").Disabled = index == 0;
        }
    }
}
