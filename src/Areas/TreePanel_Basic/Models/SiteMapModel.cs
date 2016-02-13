using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ext.Net.MVC.Examples.Areas.TreePanel_Basic.Models
{
    public class SiteMapModel
    {
        //dynamic node creation
        public static Node CreateNodeWithOutChildren(SiteMapNode siteMapNode)
        {
            Node treeNode;

            if (siteMapNode.ChildNodes != null && siteMapNode.ChildNodes.Count > 0)
            {
                treeNode = new Node();
            }
            else
            {
                treeNode = new Node();
                treeNode.Leaf = true;
            }

            if (!string.IsNullOrEmpty(siteMapNode.Url))
            {
                treeNode.Href = siteMapNode.Url.StartsWith("~/") ? siteMapNode.Url.Replace("~/", "http://examples.ext.net/") : ("http://examples.ext.net" + siteMapNode.Url);
            }

            treeNode.NodeID = siteMapNode.Key;
            treeNode.Text = siteMapNode.Title;
            treeNode.Qtip = siteMapNode.Description;

            return treeNode;
        }

        //static node creation with children
        public static Node CreateNode(SiteMapNode siteMapNode)
        {
            Node treeNode = new Node();

            if (!string.IsNullOrEmpty(siteMapNode.Url))
            {

                treeNode.CustomAttributes.Add(new ConfigItem("url", siteMapNode.Url.StartsWith("~/") ? siteMapNode.Url.Replace("~/", "http://examples.ext.net/") : ("http://examples.ext.net" + siteMapNode.Url)));
                treeNode.Href = "#";
            }

            treeNode.NodeID = siteMapNode.Key;
            treeNode.CustomAttributes.Add(new ConfigItem("hash", siteMapNode.Key.GetHashCode().ToString()));
            treeNode.Text = siteMapNode.Title;
            treeNode.Qtip = siteMapNode.Description;

            SiteMapNodeCollection children = siteMapNode.ChildNodes;

            if (children != null && children.Count > 0)
            {
                foreach (SiteMapNode mapNode in siteMapNode.ChildNodes)
                {
                    treeNode.Children.Add(SiteMapModel.CreateNode(mapNode));
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