using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ext.Net.MVC.Examples.Areas.GridPanel_Update.Models.Batch;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_Update.Controllers
{
    public class BatchController : Controller
    {
        public ActionResult Index()
        {
            TestPerson.Clear();
            return View(TestPerson.TestData);
        }

        public ActionResult HandleChanges(StoreDataHandler handler)
        {
            ChangeRecords<TestPerson> persons = handler.BatchObjectData<TestPerson>();
            var store = this.GetCmp<Store>("Store1");

            foreach (TestPerson created in persons.Created)
            {
                TestPerson.AddPerson(created);

                var record = store.GetByInternalId(created.PhantomId);
                record.CreateVariable = true;
                record.SetId(created.Id);
                record.Commit();
                created.PhantomId = null;
            }

            foreach (TestPerson deleted in persons.Deleted)
            {
                TestPerson.DeletePerson(deleted.Id.Value);
                store.CommitRemoving(deleted.Id.Value);
            }

            foreach (TestPerson updated in persons.Updated)
            {
                TestPerson.UpdatePerson(updated);

                var record = store.GetById(updated.Id.Value);
                record.Commit();
            }

            return this.Direct();
        }
    }
}
