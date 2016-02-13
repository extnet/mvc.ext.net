using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.DataView_Basic.Controllers
{
    public class OverviewController : Controller
    {
        public ActionResult Index()
        {
            string path = Server.MapPath("~/Areas/DataView_Basic/Content/images/thumbs");
            string[] files = System.IO.Directory.GetFiles(path);

            List<object> data = new List<object>(files.Length);
            foreach (string fileName in files)
            {
                System.IO.FileInfo fi = new System.IO.FileInfo(fileName);
                data.Add(new
                {
                    name = fi.Name,
                    url = Url.Content("~/Areas/DataView_Basic/Content/images/thumbs/") + fi.Name,
                    size = fi.Length,
                    lastmod = fi.LastAccessTime
                });
            }

            return View(data);
        }

        public ActionResult SubmitSelection()
        {
            StringBuilder sb = new StringBuilder();
            var view = this.GetCmp<DataView>("ImageView");
            foreach (SelectedRow row in view.SelectedRows)
            {
                sb.AppendFormat("RecordID: {0}&nbsp;&nbsp;&nbsp;&nbsp;Row index: {1}<br/>", row.RecordID, row.RowIndex);
            }
            this.GetCmp<Label>("Label1").Html = sb.ToString();

            return this.Direct();
        }

        public ActionResult AddZack()
        {
            var view = this.GetCmp<DataView>("ImageView");
            view.Select(new ModelProxy[] { this.GetCmp<Store>("ImageView.store").GetById("zack.jpg") }, true);
            return this.Direct();
        }

        public ActionResult SubmitSelectionWithValues([ModelBinder(typeof(JsonModelBinder))]Dictionary<string, string>[] images)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<table width='100%' cellspacing='15'>");
            bool addHeader = true;

            foreach (Dictionary<string, string> row in images)
            {
                if (addHeader)
                {
                    sb.Append("<tr>");
                    foreach (KeyValuePair<string, string> keyValuePair in row)
                    {
                        sb.Append("<td style='white-space:nowrap;font-weight:bold;'>");

                        sb.Append(keyValuePair.Key);

                        sb.Append("</td>");
                    }
                    sb.Append("</tr>");

                    addHeader = false;
                }

                sb.Append("<tr>");
                foreach (KeyValuePair<string, string> keyValuePair in row)
                {
                    sb.Append("<td style='white-space:nowrap;'>");

                    sb.Append(keyValuePair.Value);

                    sb.Append("</td>");
                }
                sb.Append("</tr>");
            }
            sb.Append("</table>");

            this.GetCmp<Label>("Label1").Html = sb.ToString();

            return this.Direct();
        }
    }
}
