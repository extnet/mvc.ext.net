using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_ComponentColumn.Overview.Controllers
{
    public class OverviewController : Controller
    {
        public ActionResult Index()
        {
            return View(TestData.GetData());
        }

        public ActionResult DoTasks(string tasks)
        {
            var tasksDict = JSON.Deserialize<Dictionary<string, string>[]>(tasks);
            var store = this.GetCmp<Store>("StoreTasks");

            foreach (var task in tasksDict)
            {
                var id = JSON.Deserialize<int>(task["TaskID"]);
                var progress = JSON.Deserialize<float>(task["Progress"]);
                var status = JSON.Deserialize<int>(task["Status"]);

                var record = store.GetById(id);
                record.BeginEdit();

                if (status == 1)
                {
                    record.Set("Status", 2);
                }

                progress += 0.2f;

                record.Set("Progress", progress);

                if (progress >= 1)
                {
                    record.Set("Status", 3);
                }

                record.EndEdit();
            }

            return this.Direct();
        }
    }
}
