using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ext.Net.MVC.Examples.Areas.TreePanel_Basic.Models;

namespace Ext.Net.MVC.Examples.Areas.TreePanel_Basic.Controllers
{
    public class DragDrop_Between_TreesController : Controller
    {
        public ActionResult Index()
        {
            SiteMapNode siteNode = SiteMap.RootNode;
            Node node = NodeHelper.CreateNodeWithOutChildren(siteNode);
            node.AllowDrag = true;
            node.Expanded = true;

            return View(node);
        }

        public ActionResult GetNodes(string node)
        {
            if (!string.IsNullOrEmpty(node))
            {
                NodeCollection nodes = new NodeCollection();
                SiteMapNode siteMapNode = SiteMap.Provider.FindSiteMapNodeFromKey(node);

                if (siteMapNode == null)
                {
                    return this.Store(nodes);
                }

                SiteMapNodeCollection children = siteMapNode.ChildNodes;

                if (children != null && children.Count > 0)
                {
                    foreach (SiteMapNode mapNode in siteMapNode.ChildNodes)
                    {
                        nodes.Add(NodeHelper.CreateNodeWithOutChildren(mapNode));
                    }
                }

                return this.Store(nodes);
            }

            return new HttpStatusCodeResult(500);
        }
    }
}
