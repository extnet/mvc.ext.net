using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using Ext.Net.MVC.Examples.Areas.GridPanel_Spreadsheet.Models;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_Spreadsheet.Controllers
{
    public class SubmitController : Controller
    {
        public ActionResult Index()
        {
            return this.View(GridPanel_SpreadsheetSubmitModel.GetData());
        }

        public ActionResult Reload()
        {
            return this.Store(GridPanel_SpreadsheetSubmitModel.GetData());
        }

        public ActionResult Submit(string selectedData)
        {
            SpreadsheetSelectedData spreadsheetSelectedData = JSON.Deserialize<SpreadsheetSelectedData>(selectedData);
            var label = X.GetCmp<Label>("Label1");

            if (!spreadsheetSelectedData.IsEmpty())
            {
                if (spreadsheetSelectedData.Rows.Count > 0)
                {
                    this.OutputRows(spreadsheetSelectedData.Rows, label);
                }
                else if (spreadsheetSelectedData.Columns.Count > 0)
                {
                    this.OutputColumns(spreadsheetSelectedData.Columns, label);
                }
                else
                {
                    this.OutputCells(spreadsheetSelectedData, label);
                }
            }
            else
            {
                label.Html = "<h3>No selection</h3>";
            }

            return this.Direct();
        }

        public void AddHeaderCell(StringBuilder sb, string value)
        {
            sb.Append("<td style='white-space:nowrap;font-weight:bold;'>");
            sb.Append(value);
            sb.Append("</td>");
        }

        public void AddCell(StringBuilder sb, string value)
        {
            sb.Append("<td style='white-space:nowrap;'>");
            sb.Append(value);
            sb.Append("</td>");
        }

        protected void OutputRows(SelectedRowCollection rows, Label label)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<table width='100%' cellspacing='5'>");
            bool addHeader = true;

            foreach (SelectedRow rowd in rows)
            {
                if (addHeader)
                {
                    sb.Append("<tr>");
                    this.AddHeaderCell(sb, "RecordID");
                    this.AddHeaderCell(sb, "RowIndex");
                    sb.Append("</tr>");

                    addHeader = false;
                }

                sb.Append("<tr>");

                this.AddCell(sb, rowd.RecordID);
                this.AddCell(sb, rowd.RowIndex.ToString());

                sb.Append("</tr>");
            }

            sb.Append("</table>");
            label.Html = sb.ToString();
        }

        protected void OutputColumns(SelectedColumnCollection columns, Label label)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<table width='100%' cellspacing='5'>");
            bool addHeader = true;

            foreach (SelectedColumn columnd in columns)
            {
                if (addHeader)
                {
                    sb.Append("<tr>");
                    this.AddHeaderCell(sb, "ColumnID");
                    this.AddHeaderCell(sb, "ColumnDataIndex");
                    this.AddHeaderCell(sb, "ColumnIndex");
                    sb.Append("</tr>");

                    addHeader = false;
                }

                sb.Append("<tr>");

                this.AddCell(sb, columnd.ColumnID);
                this.AddCell(sb, columnd.ColumnDataIndex);
                this.AddCell(sb, columnd.ColumnIndex.ToString());

                sb.Append("</tr>");
            }

            sb.Append("</table>");
            label.Html = sb.ToString();
        }

        protected void OutputCells(SpreadsheetSelectedData selectedData, Label label)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<table width='100%' cellspacing='5'>");

            sb.Append("<tr>");
            this.AddHeaderCell(sb, "Range");
            this.AddHeaderCell(sb, "RowIndex");
            this.AddHeaderCell(sb, "RecordID");
            this.AddHeaderCell(sb, "ColumnID");
            this.AddHeaderCell(sb, "ColumnDataIndex");
            this.AddHeaderCell(sb, "ColumnIndex");
            sb.Append("</tr>");

            sb.Append("<tr>");
            this.AddCell(sb, "Start");
            this.AddCell(sb, selectedData.RangeStart.RowIndex.ToString());
            this.AddCell(sb, selectedData.RangeStart.RecordID);
            this.AddCell(sb, selectedData.RangeStart.ColumnID);
            this.AddCell(sb, selectedData.RangeStart.ColumnDataIndex);
            this.AddCell(sb, selectedData.RangeStart.ColumnIndex.ToString());
            sb.Append("</tr>");

            sb.Append("<tr>");
            this.AddCell(sb, "End");
            this.AddCell(sb, selectedData.RangeEnd.RowIndex.ToString());
            this.AddCell(sb, selectedData.RangeEnd.RecordID);
            this.AddCell(sb, selectedData.RangeEnd.ColumnID);
            this.AddCell(sb, selectedData.RangeEnd.ColumnDataIndex);
            this.AddCell(sb, selectedData.RangeEnd.ColumnIndex.ToString());
            sb.Append("</tr>");

            sb.Append("</table>");
            label.Html = sb.ToString();
        }

        public ActionResult SubmitWithValues(string selectedData)
        {
            Label label = X.GetCmp<Label>("Label1");
            Dictionary<string, string>[] values = JSON.Deserialize<Dictionary<string, string>[]>(selectedData);

            if (values.Length > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<table width='100%' cellspacing='15'>");
                bool addHeader = true;

                foreach (Dictionary<string, string> row in values)
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
                label.Html = sb.ToString();
            }
            else
            {
                label.Html = "<h3>No selection</h3>";
            }

            return this.Direct();
        }
    }
}
