using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ext.Net.MVC.Examples.Areas.TreePanel_Advanced.Models;

namespace Ext.Net.MVC.Examples.Areas.TreePanel_Advanced.Controllers
{
    public class Image_OrganizerController : Controller
    {        
        public ActionResult Index()
        {
            return View(Image_OrganizerModel.GetFiles(Url.Content("~/Areas/DataView_Basic/Content/images/touch-icons")));
        }

        public ActionResult AddNewAlbum()
        {            
            this.GetCmp<TreePanel>("TreePanel1").GetRootNode().AppendChild(new Node
            {
                NodeID = (++NewIndex).ToString(),
                CustomAttributes = 
                {
                    new ConfigItem("name", "Album " + NewIndex, ParameterMode.Value)
                },
                IconCls = "album-btn",
                AllowDrag = false,
                EmptyChildren = true
            });

            return this.Direct();
        }

        private int NewIndex
        {
            get
            {
                return (int)(Session["newIndex"] ?? 1);
            }
            set
            {
                Session["newIndex"] = value;
            }
        }
    }
}
