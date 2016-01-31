using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ext.Net.MVC.Examples.Areas.TreePanel_Basic.Models
{
    public class Reorder_NodesModel
    {
        public static Node CreateNode(SiteMapNode siteMapNode)
        {
            Ext.Net.Node node = new Ext.Net.Node();

            node.NodeID = siteMapNode.Key;
            node.Text = siteMapNode.Title;
            node.Qtip = siteMapNode.Description;

            SiteMapNodeCollection children = siteMapNode.ChildNodes;

            if (children != null && children.Count > 0)
            {
                foreach (SiteMapNode mapNode in siteMapNode.ChildNodes)
                {
                    node.Children.Add(CreateNode(mapNode));
                }
            }
            else
            {
                node.Leaf = true;
            }

            return node;
        }
    }
}