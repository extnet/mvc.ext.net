using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Models.Controllers
{
    public class Editor_TemplateController : Controller
    {
        public ActionResult Index()
        {
            return View(Customer.GetCustomer());
        }

        public ActionResult Submit(Customer customer)
        {
            X.Msg.Alert("Customer Submit", JSON.Serialize(customer)).Show();
            return this.FormPanel();
        }

        public ActionResult ShippingAddressSubmit([Bind(Prefix="ShippingAddress")]Address address)
        {
            X.Msg.Alert("Shipping Address Submit", JSON.Serialize(address)).Show();
            return this.FormPanel();
        }

        public ActionResult BillingAddressSubmit([Bind(Prefix = "BillingAddress")]Address address)
        {
            X.Msg.Alert("Billing Address Submit", JSON.Serialize(address)).Show();
            return this.FormPanel();
        }
    }
}
