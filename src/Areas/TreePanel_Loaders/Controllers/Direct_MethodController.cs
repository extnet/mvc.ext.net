using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.TreePanel_Loaders.Controllers
{
    [DirectController(AreaName = "TreePanel_Loaders", GenerateProxyForOtherControllers = false, IDMode = DirectMethodProxyIDMode.None)]
    public class Direct_MethodController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [DirectMethod]
        public ActionResult NodeLoad(string node)
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

            return this.Direct(nodes);
        }
    }
}
