using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using Wilco.SyntaxHighlighting;

namespace Ext.Net.MVC.Examples
{
    public class HighLighterUtils
    {
        public static string AspxToHtml(string source)
        {
            HighlighterBase hl = new ASPXHighlighter();

            return SourceToHtml(source, hl);
        }

        public static string AspxToHtml(Uri url)
        {
            HighlighterBase hl = new ASPXHighlighter();

            return SourceToHtml(url, hl);
        }

        public static string CSharpToHtml(string source)
        {
            HighlighterBase hl = new CSharpHighlighter();

            return SourceToHtml(source, hl);
        }

        public static string CSharpToHtml(Uri url)
        {
            HighlighterBase hl = new CSharpHighlighter();

            return SourceToHtml(url, hl);
        }

        public static string XmlToHtml(string source)
        {
            HighlighterBase hl = new XMLHighlighter();

            return SourceToHtml(source, hl);
        }

        public static string XmlToHtml(Uri url)
        {
            HighlighterBase hl = new XMLHighlighter();

            return SourceToHtml(url, hl);
        }

        public static string JsToHtml(string source)
        {
            HighlighterBase hl = new JavaScriptHighlighter();

            return SourceToHtml(source, hl);
        }

        public static string JsToHtml(Uri url)
        {
            HighlighterBase hl = new JavaScriptHighlighter();

            return SourceToHtml(url, hl);
        }

        public static string SourceToHtml(Uri uri, HighlighterBase highlighter)
        {
            string filePath = HttpContext.Current.Server.MapPath(uri.LocalPath);

            return SourceToHtml(File.ReadAllText(filePath), highlighter);
        }
        
        public static string SourceToHtml(string source, HighlighterBase highlighter)
        {
            HtmlParser parser = new HtmlParser();
            highlighter.Parser = parser;

            source = Regex.Replace(source, "<%--Start exclude--%>.*?<%--End exclude--%>", "", RegexOptions.Singleline);

            string s = highlighter.Parse(source);

            return string.Concat("<pre style='margin: 0px;font-size:14px;'>", s, "</pre>");
        }
    }
}