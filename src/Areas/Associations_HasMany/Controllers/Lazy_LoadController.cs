using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Ext.Net.MVC.Examples.Areas.Associations_HasMany.Models;

namespace Ext.Net.MVC.Examples.Areas.Associations_HasMany.Controllers
{
    [DirectController(AreaName = "Associations_HasMany", IDMode = DirectMethodProxyIDMode.None)]
    public class Lazy_LoadController : Controller
    {
        public ActionResult Index() => View();

        public ActionResult RenderCustomerGrid(string containerId) => new PartialViewResult
        {
            ContainerId = containerId,
            RenderMode = RenderMode.AddTo,
            ViewName = "CustomerGrid",
            WrapByScriptTag = false
        };

        public ActionResult RenderLoggerPanel(string containerId) => new PartialViewResult
        {
            ContainerId = containerId,
            RenderMode = RenderMode.AddTo,
            ViewName = "Logger",
            WrapByScriptTag = false
        };

        public ActionResult RenderModelsCluster(string containerId) => new PartialViewResult
        {
            ContainerId = containerId,
            ViewName = "Models",
            WrapByScriptTag = false
        };

        public ActionResult RenderOrderGrid(string containerId) => new PartialViewResult
        {
            ContainerId = containerId,
            ViewName = "OrderGrid",
            WrapByScriptTag = false
        };

        [DirectMethod]
        public ActionResult GetCustomers(string action, Dictionary<string, object> extraParams)
        {
            var db = new Lazy_LoadModels();

            if (extraParams.ContainsKey("id"))
            {
                int id = Convert.ToInt32(extraParams["id"]);
                return this.Direct(db.Customers.Where(c => c.Id == id));
            }

            return this.Direct(db.Customers);
        }

        [DirectMethod]
        public ActionResult GetOrders(string action, Dictionary<string, object> extraParams)
        {
            var db = new Lazy_LoadModels();

            if (extraParams.ContainsKey("id"))
            {
                int id = Convert.ToInt32(extraParams["id"]);
                return this.Direct(db.Orders.Where(o => o.Id == id));
            }

            int customerId = -1;

            StoreRequestParameters prms = new StoreRequestParameters(extraParams);
            DataFilter[] filter = prms.Filter;
            if (filter.Length > 0 && filter[0].Property == "CustomerId")
            {
                customerId = Convert.ToInt32(filter[0].Value);
            }

            return this.Direct(db.Orders.Where(o => o.CustomerId == customerId));
        }

        [DirectMethod]
        public ActionResult GetOrderItems(string action, Dictionary<string, object> extraParams)
        {
            var db = new Lazy_LoadModels();

            if (extraParams.ContainsKey("id"))
            {
                int id = Convert.ToInt32(extraParams["id"]);
                return this.Direct(db.OrderItems.Where(oi => oi.Id == id));
            }

            int orderId = -1;

            StoreRequestParameters prms = new StoreRequestParameters(extraParams);
            DataFilter[] filter = prms.Filter;
            if (filter.Length > 0 && filter[0].Property == "OrderId")
            {
                orderId = Convert.ToInt32(filter[0].Value);
            }

            return this.Direct(db.OrderItems.Where(oi => oi.OrderId == orderId));
        }
    }
}
