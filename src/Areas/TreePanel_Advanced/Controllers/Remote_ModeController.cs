using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.TreePanel_Advanced.Controllers
{
    public class Remote_ModeController : Controller
    {       
        public ActionResult Index()
        {
            return View();
        }

        public StoreResult GetNodes(string node)
        {
            NodeCollection nodes = new NodeCollection(false);

            string prefix = DateTime.Now.Second + "_";
            for (int i = 0; i < 10; i++)
            {
                Node newNode = new Node();
                newNode.NodeID = i.ToString();
                newNode.Text = prefix + i;
                newNode.Leaf = true;
                nodes.Add(newNode);
            }

            return this.Store(nodes);
        }

        public ActionResult RemoteEdit(string id, string field, string newValue, string oldValue)
        {
            return this.RemoteTree(newValue + "_echo");
            //return this.RemoteTree(false, "Renaming is disabled");
        }

        public ActionResult RemoteEdit_RowEditing(string id, [ModelBinder(typeof(JsonModelBinder))]Dictionary<string, object> newValues, [ModelBinder(typeof(JsonModelBinder))]Dictionary<string, object> oldValues)
        {
            return this.RemoteTree(new { text = newValues["text"].ToString() + "_echo", number = int.Parse(newValues["number"].ToString()) + 100 });
        }

        public ActionResult RemoteRemove(string id, string parentId)
        {
            return this.RemoteTree();
        }

        public ActionResult RemoteAppend(string parentId, string text)
        {
            return this.RemoteTree(null, "newId", new { text = text + "_new" });
        }

        public ActionResult RemoteInsert(int index, string parentId, string text)
        {
            return this.RemoteTree(null, "newId", new { text = text + "_new" });
        }

        public ActionResult RemoteMove(string[] ids, string targetId, string[] parentIds, string point)
        {
            return this.RemoteTree();
        }
    }
}
