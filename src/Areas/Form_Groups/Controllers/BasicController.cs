using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Form_Groups.Controllers
{
    public class BasicController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult Button1Click(List<FieldsGroupModel> groups1, List<FieldsGroupModel> groups2)
        {
            StringBuilder sb = new StringBuilder(255);

            sb.Append("<h1>Checked Items</h1>");
            sb.Append("<h2>CheckboxGroups</h2>");
            sb.Append("<blockquote>");

            groups1.ForEach(delegate(FieldsGroupModel group)
            {
                int count = 0;

                group.CheckedItems.ForEach(delegate(CheckedFieldModel checkbox)
                {
                    if (count == 0)
                    {
                        sb.AppendFormat("<h3>{0}</h3>", group.FieldLabel);
                        sb.Append("<blockquote>");
                    }
                    sb.AppendFormat("{0}<br />", checkbox.BoxLabel);
                    count++;
                });

                if (count > 0)
                {
                    sb.Append("</blockquote>");
                }
            });

            sb.Append("</blockquote>");

            sb.Append("<h2>RadioGroups</h2>");
            sb.Append("<blockquote>");

            groups2.ForEach(delegate(FieldsGroupModel group)
            {
                int count = 0;

                group.CheckedItems.ForEach(delegate(CheckedFieldModel radio)
                {
                    if (count == 0)
                    {
                        sb.AppendFormat("<h3>{0}</h3>", group.FieldLabel);
                        sb.Append("<blockquote>");
                    }
                    sb.AppendFormat("{0}<br />", radio.BoxLabel);
                    count++;
                });

                if (count > 0)
                {
                    sb.Append("</blockquote>");
                }
            });

            sb.Append("</blockquote>");

            this.GetCmp<Label>("Label1").Html = sb.ToString();

            return this.Direct();
        }
    }

    public class CheckedFieldModel
    {
        public string BoxLabel { get; set; }
    }

    public class FieldsGroupModel
    {
        public FieldsGroupModel()
        {
            this.CheckedItems = new List<CheckedFieldModel>();
        }

        public string FieldLabel { get; set; }

        public List<CheckedFieldModel> CheckedItems { get; set; }
    }
}
