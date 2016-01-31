using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_Editable.Editor_with_DirectMethod.Controllers
{
    public class Editor_with_DirectMethodController : Controller
    {
        public ActionResult Index()
        {
            return View(Company.GetAll());
        }

        public DirectResult Edit(int id, string field, string oldValue, string newValue, object customer)
        {
            string message = "<b>Property:</b> {0}<br /><b>Field:</b> {1}<br /><b>Old Value:</b> {2}<br /><b>New Value:</b> {3}";

            // Send Message...
            X.Msg.Notify(new NotificationConfig()
            {
                Title = "Edit Record #" + id.ToString(),
                Html = string.Format(message, id, field, oldValue, newValue),
                Width = 250,
                Height = 150
            }).Show();

            X.GetCmp<Store>("Store1").GetById(id).Commit();

            return this.Direct();
        }
    }
}
