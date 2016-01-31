using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ext.Net.MVC.Examples.Areas.TreePanel_Basic.Models
{
    public class EditorsModel
    {
        public static Ext.Net.Node BuildTree()
        {
            Ext.Net.Node root = new Ext.Net.Node();
            root.Text = "Root";

            for (int i = 0; i < 3; i++)
            {
                Ext.Net.Node node = new Ext.Net.Node();
                node.Text = "TextField node";
                node.Leaf = true;
                node.CustomAttributes.Add(new ConfigItem("editor", "0", ParameterMode.Raw));
                root.Children.Add(node);

                node = new Ext.Net.Node();
                node.Text = "1";
                node.Leaf = true;
                node.CustomAttributes.Add(new ConfigItem("editor", "1", ParameterMode.Raw));
                root.Children.Add(node);

                node = new Ext.Net.Node();
                node.Text = "ComboBox node";
                node.Leaf = true;
                node.CustomAttributes.Add(new ConfigItem("editor", "2", ParameterMode.Raw));
                root.Children.Add(node);
            }

            return root;
        }
    }
}