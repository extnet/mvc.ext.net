using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.MessageBox_Basic.Controllers
{
    [DirectController(AreaName = "MessageBox_Basic")]
    public class ButtonsConfigController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [DirectMethod(Namespace = "CompanyX")]
        public ActionResult DoConfirm()
        {
            // Manually configure Handler...
            //Msg.Confirm("Message", "Confirm?", "if (buttonId == 'yes') { CompanyX.DoYes(); } else { CompanyX.DoNo(); }").Show();

            // Configure individualock Buttons using a ButtonsConfig...
           X.Msg.Confirm("Message", "Confirm?", new MessageBoxButtonsConfig
            {
                Yes = new MessageBoxButtonConfig
                {
                    Handler = "CompanyX.MessageBox_Basic.DoYes()",
                    Text = "Yes Please"
                },
                No = new MessageBoxButtonConfig
                {
                    Handler = "CompanyX.MessageBox_Basic.DoNo()",
                    Text = "No Thanks"
                }
            }).Show();

            return this.Direct();
        }

        [DirectMethod(Namespace = "CompanyX")]
        public ActionResult DoYes()
        {
            this.GetCmp<Label>("Label1").Text = "YES";
            return this.Direct();
        }

        [DirectMethod(Namespace = "CompanyX")]
        public ActionResult DoNo()
        {
            this.GetCmp<Label>("Label1").Text = "NO";
            return this.Direct();
        }
    }
}
