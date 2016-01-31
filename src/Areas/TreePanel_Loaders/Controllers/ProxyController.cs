using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.TreePanel_Loaders.Controllers
{
    public class ProxyController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public StoreResult GetChildren(string node)
        {
            NodeCollection nodes = new Ext.Net.NodeCollection();

            if (!string.IsNullOrEmpty(node))
            {
                for (int i = 1; i < 6; i++)
                {
                    Node asyncNode = new Node();
                    asyncNode.Text = node + i;
                    asyncNode.NodeID = node + i;
                    nodes.Add(asyncNode);
                }

                for (int i = 6; i < 11; i++)
                {
                    Node treeNode = new Node();
                    treeNode.Text = node + i;
                    treeNode.NodeID = node + i;
                    treeNode.Leaf = true;
                    nodes.Add(treeNode);
                }
            }

            return this.Store(nodes);
        }
    }
}
