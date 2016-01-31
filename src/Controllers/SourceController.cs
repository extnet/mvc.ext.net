using System.Globalization;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Web.Mvc;

using Wilco.SyntaxHighlighting;

namespace Ext.Net.MVC.Examples
{
    [DirectController]
    public class SourceController : System.Web.Mvc.Controller
    {
        private string CutFromTo(string str, string start, string end)
        {
            var startPos = str.IndexOf(start);

            if (startPos < 0)
            {
                return string.Empty;
            }

            var endPos = str.IndexOf(end, startPos);

            if (endPos < 0)
            {
                return string.Empty;
            }

            return str.Substring(startPos + start.Length, endPos - startPos - start.Length);
        }

        [DirectMethod]
        [OutputCache(Duration = 3600, VaryByParam = "url")]
        public ActionResult GetSourceTabs(string id, string url, string windowId)
        {
            var tabs = SourceModel.BuildSourceTabs(id, url);
            tabs.Render(windowId, RenderMode.AddTo);
            return this.Direct();
        }

        [OutputCache(Duration = 3600, VaryByParam = "file")]
        public ActionResult GetSourceFile(string file)
        {
            string path = this.HttpContext.Server.MapPath(file);
            string examplesRoot = this.HttpContext.Server.MapPath(ExamplesModel.ApplicationRoot + "/Areas/");
            var fi = new FileInfo(path);

            if (!path.StartsWith(examplesRoot, true, CultureInfo.CurrentCulture))
            {
                return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest);
            }

            HighlighterBase hb = null;
            bool markup = false;

            switch (fi.Extension.ToLowerInvariant())
            {
                case ".aspx":
                case ".ascx":
                case ".cshtml":
                case ".master":
                    hb = new ASPXHighlighter();
                    markup = true;
                    break;
                case ".cs":
                    hb = new CSharpHighlighter();
                    break;
                case ".xml":
                case ".xsl":
                    hb = new XMLHighlighter();
                    break;
                case ".js":
                    hb = new JavaScriptHighlighter();
                    break;
                case ".css":
                    hb = new CSSHighlighter();
                    break;
                default:
                    return Content(System.IO.File.ReadAllText(fi.FullName), "text/plain");                    
            }

            string source = System.IO.File.ReadAllText(fi.FullName);

            if (markup)
            {
                string origCSScriptStart = @"<script runat=""server"">";
                string origCSScriptEnd = @"</script>";
                string origJSScriptStart = @"<script>";
                string origJSScriptEnd = @"</script>";
                string origCSScriptText = CutFromTo(source, origCSScriptStart, origCSScriptEnd);
                string origJSScriptText = CutFromTo(source, origJSScriptStart, origJSScriptEnd);

                source = HighLighterUtils.SourceToHtml(source, hb);

                if (!string.IsNullOrEmpty(origCSScriptText))
                {
                    string strCSScriptStart = CutFromTo(HighLighterUtils.SourceToHtml(origCSScriptStart, hb), ">", "</pre>");
                    string strCSScriptEnd = CutFromTo(HighLighterUtils.SourceToHtml(origCSScriptEnd, hb), ">", "</pre>");
                    string csText = CutFromTo(source, strCSScriptStart, strCSScriptEnd);

                    source = source.Replace(csText, CutFromTo(HighLighterUtils.CSharpToHtml(origCSScriptText), ">", "</pre>"));
                }

                if (!string.IsNullOrEmpty(origJSScriptText))
                {
                    string strJSScriptStart = CutFromTo(HighLighterUtils.SourceToHtml(origJSScriptStart, hb), ">", "</pre>");
                    string strJSScriptEnd = CutFromTo(HighLighterUtils.SourceToHtml(origJSScriptEnd, hb), ">", "</pre>");
                    string jsText = CutFromTo(source, strJSScriptStart, strJSScriptEnd);

                    source = source.Replace(jsText, CutFromTo(HighLighterUtils.JsToHtml(origJSScriptText), ">", "</pre>"));
                }
            }
            else
            {
                source = HighLighterUtils.SourceToHtml(source, hb);
            }

            return this.Content(source, "text/html");
        }

        [DirectMethod]
        [OutputCache(Duration = 3600, VaryByParam = "url")]
        public ActionResult DownloadExample(string url)
        {            
            if (string.IsNullOrEmpty(url))
            {
                return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest);
            }            
            
            string path = this.HttpContext.Server.MapPath("~/Areas" + url);
            string examplesRoot = this.HttpContext.Server.MapPath(ExamplesModel.ApplicationRoot + "/Areas/");

            if (url.ToLowerInvariant() == "all")
            {
                return new ZipResult(examplesRoot, "Ext_Net_MVC_Samples");
            }

            if (!path.StartsWith(examplesRoot, true, CultureInfo.CurrentCulture))
            {
                return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest);
            }

            return new ZipResult(SourceModel.GetFiles(url, true), new DirectoryInfo(path).Name);
        }
    }
}
