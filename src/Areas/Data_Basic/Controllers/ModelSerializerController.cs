using System.Collections.Generic;
using System.Web.Mvc;
using Ext.Net.MVC.Examples.Areas.Data_Basic.Models;

namespace Ext.Net.MVC.Examples.Areas.Data_Basic.Controllers
{
    public class ModelSerializerController : Controller
    {
        public ActionResult Index()
        {
            return View(ModelSerializerModel.GetFullModel());
        }

        public ActionResult GetFullData()
        {
            return this.Store(ModelSerializerModel.Data, ModelSerializerModel.GetFullModel());
        }

        public ActionResult GetPartialData()
        {
            return this.Store(ModelSerializerModel.Data, new ModelFieldCollection()
            {
                new ModelField("Company"),
                new ModelField("Price")
            });
        }

        public ActionResult GetListOfCompaniesWithSizes()
        {
            string data = ModelSerializer.Serialize(ModelSerializerModel.Data, new ModelFieldCollection()
            {
                new ModelField("Company"),
                new ModelField("Size")
            });

            X.Msg.Alert("Companies", data).Show();

            return this.Direct();
        }
    }
}
