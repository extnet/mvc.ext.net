using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ext.Net.MVC.Examples.Areas.GridPanel_Paging_and_Sorting.Models;
using System.Xml;
using System.Text;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_Paging_and_Sorting.Controllers
{
    public class LocalController : Controller
    {
        public ActionResult Index()
        {
            return View(Companies.GetAllCompanies());
        }

        public ActionResult Read()
        {
            return this.Store(Companies.GetAllCompanies());
        }

        public ActionResult Submit(SubmitHandler handler)
        {
            return this.File(new System.Text.UTF8Encoding().GetBytes(handler.Xml.OuterXml), "application/xml", "submittedData.xml");
        }

        public ActionResult Sync(StoreDataHandler handler)
        {
            XmlNode xml = handler.XmlData;
            StringBuilder sb = new StringBuilder();

            XmlNode updated = xml.SelectSingleNode("records/Updated");

            if (updated != null)
            {
                sb.Append("<p>Updated:</p>");

                XmlNodeList uRecords = updated.SelectNodes("record");

                foreach (XmlNode record in uRecords)
                {
                    sb.Append("<p>").Append(Server.HtmlEncode(record.InnerXml)).Append("</p>");
                }

                sb.Append("<br/>");
            }

            XmlNode inserted = xml.SelectSingleNode("records/Created");

            if (inserted != null)
            {
                sb.Append("<p>Created:</p>");

                XmlNodeList iRecords = inserted.SelectNodes("record");

                foreach (XmlNode record in iRecords)
                {
                    sb.Append("<p>").Append(Server.HtmlEncode(record.InnerXml)).Append("</p>");
                }

                sb.Append("<br/>");
            }

            XmlNode deleted = xml.SelectSingleNode("records/Deleted");

            if (deleted != null)
            {
                sb.Append("<p>Deleted:</p>");

                XmlNodeList dRecords = deleted.SelectNodes("record");

                foreach (XmlNode record in dRecords)
                {
                    sb.Append("<p>").Append(Server.HtmlEncode(record.InnerXml)).Append("</p>");
                }

                sb.Append("<br/>");
            }

            this.GetCmp<Store>("Store1").CommitChanges();
            this.GetCmp<Label>("Label1").Html = sb.ToString();

            return this.Direct();
        }
    }
}
