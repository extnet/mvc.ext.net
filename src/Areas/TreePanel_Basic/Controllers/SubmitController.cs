using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.TreePanel_Basic.Controllers
{
    public class SubmitController : Controller
    {
        public ActionResult Index()
        {
            Node root = new Node();
            root.Text = "Root";

            bool submit = true;

            for (int i = 0; i < 10; i++)
            {
                Node node = new Node();
                node.NodeID = (i + 1).ToString();
                node.Text = "Node" + (i + 1);
                node.Leaf = true;
                node.CustomAttributes.Add(new ConfigItem("submit", JSON.Serialize(submit), ParameterMode.Raw));
                root.Children.Add(node);
                submit = !submit;
            }

            return View(root);
        }

        public ActionResult SubmitNodes(SubmittedNode data)
        {
            X.Msg.Alert("Submit", "You have submitted " + data.Children.Count + " nodes").Show();
            return this.Direct();
        }
    }
}
