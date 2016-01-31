using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ext.Net.MVC.Examples.Areas.TreePanel_Basic.Models
{
    public class NodeHelper
    {
        public static Node CreateNodeWithOutChildren(SiteMapNode siteMapNode)
        {
            Node treeNode;

            if (siteMapNode.ChildNodes != null && siteMapNode.ChildNodes.Count > 0)
            {
                treeNode = new Node();
            }
            else
            {
                treeNode = new Ext.Net.Node();
                treeNode.Leaf = true;
            }

            treeNode.NodeID = siteMapNode.Key;
            treeNode.Text = siteMapNode.Title;
            treeNode.Qtip = siteMapNode.Description;

            return treeNode;
        }
    }
}