using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ext.Net.MVC.Examples.Areas.TreePanel_Basic.Models
{
    public class Refresh_Static_TreeModel
    {
        public static Ext.Net.Node BuildTree()
        {
            Ext.Net.Node root = new Ext.Net.Node();
            root.Text = "Root";
            root.Expanded = true;
            string prefix = DateTime.Now.Second + "_";

            for (int i = 0; i < 10; i++)
            {
                Ext.Net.Node node = new Ext.Net.Node();
                node.Text = prefix + i;
                node.Leaf = true;
                root.Children.Add(node);
            }

            return root;
        }
    }
}