using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ext.Net.MVC.Examples.Areas.GridPanel_Update.Models.AutoSave;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_Update.Controllers
{
    public class AutoSaveController : Controller
    {
        public ActionResult Index()
        {
            TestPerson.Clear();
            return View(TestPerson.TestData);
        }

        public ActionResult HandleChanges(StoreDataHandler handler)
        {
            List<TestPerson> persons = handler.ObjectData<TestPerson>();
            string errorMessage = null;

            if (handler.Action == StoreAction.Create)
            {
                foreach (TestPerson created in persons)
                {
                    TestPerson.AddPerson(created);
                }
            }
            else if (handler.Action == StoreAction.Destroy)
            {
                foreach (TestPerson deleted in persons)
                {
                    TestPerson.DeletePerson(deleted.Id.Value);
                }
            }
            else if (handler.Action == StoreAction.Update)
            {
                foreach (TestPerson updated in persons)
                {
                    try
                    {
                        TestPerson.UpdatePerson(updated);
                    }
                    catch(Exception e)
                    {
                        errorMessage = e.Message;
                    }
                }
            }

            if (errorMessage != null)
            {
                return this.Store(errorMessage);
            }

            return handler.Action != StoreAction.Destroy ? (ActionResult)this.Store(persons) : (ActionResult)this.Content("");
        }
    }
}
