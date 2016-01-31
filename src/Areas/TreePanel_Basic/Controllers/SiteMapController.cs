using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ext.Net.MVC.Examples.Areas.TreePanel_Basic.Models;

namespace Ext.Net.MVC.Examples.Areas.TreePanel_Basic.Controllers
{
    public class SiteMapController : Controller
    {
        public ActionResult Index()
        {
            return View(SiteMapModel.CreateNode(SiteMap.RootNode));
        }

        public ActionResult LoadPages(string node)
        {
            NodeCollection result = null;
            if (node == "_root")
            {
                result = SiteMapModel.CreateNode(SiteMap.RootNode).Children;
            }
            else
            {
                SiteMapNode siteMapNode = SiteMap.Provider.FindSiteMapNodeFromKey(node);
                SiteMapNodeCollection children = siteMapNode.ChildNodes;
                result = new NodeCollection();

                if (children != null && children.Count > 0)
                {
                    foreach (SiteMapNode mapNode in siteMapNode.ChildNodes)
                    {
                        result.Add(SiteMapModel.CreateNodeWithOutChildren(mapNode));
                    }
                }
            }

            return this.Store(result);
        }
    }
}
