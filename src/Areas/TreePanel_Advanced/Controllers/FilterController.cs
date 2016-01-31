using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ext.Net.MVC.Examples.Areas.TreePanel_Advanced.Models;

namespace Ext.Net.MVC.Examples.Areas.TreePanel_Advanced.Controllers
{
    public class FilterController : Controller
    {
        public ActionResult Index()
        {
            SiteMapNode siteNode = SiteMap.RootNode;
            Node root = new Node();
            root.AllowDrag = false;
            root.Expanded = true;
            root.Children.Add(FilterModel.CreateNode(siteNode));

            return View(root);
        }
    }
}
