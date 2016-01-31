using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ext.Net.MVC.Examples.Areas.TreePanel_Advanced.Models
{
    public class FilterModel
    {
        public static Node CreateNode(SiteMapNode siteMapNode)
        {
            Node treeNode = new Node();

            treeNode.NodeID = siteMapNode.Key;
            treeNode.Text = siteMapNode.Title;
            treeNode.Qtip = siteMapNode.Description;

            SiteMapNodeCollection children = siteMapNode.ChildNodes;

            if (children != null && children.Count > 0)
            {
                foreach (SiteMapNode mapNode in siteMapNode.ChildNodes)
                {
                    treeNode.Children.Add(FilterModel.CreateNode(mapNode));
                }
            }
            else
            {
                treeNode.Leaf = true;
            }

            return treeNode;
        }
    }
}