using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using xButton = Ext.Net.Button;
using xWindow = Ext.Net.Window;

namespace Ext.Net.Examples
{
    /// <summary>
    /// 
    /// </summary>
    [ParseChildren(true)]
    [PersistChildren(false)]
    [Description("")]
    public partial class HighLighterButton : System.Web.UI.UserControl
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        [Description("")]
        protected void Page_Load(object sender, EventArgs e) { }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public string Url
        {
            get; set;
        }

        public Syntax Syntax
        {
            get;set;
        }

        private xButton button;

        /// <summary>
        /// 
        /// </summary>
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("")]
        public xButton Button
        {
            get
            {
                return this.button;
            }
        }

        private xWindow window;

        [PersistenceMode(PersistenceMode.InnerProperty)]
        public xWindow Window
        {
            get
            {
                return this.window;
            }
        }

        protected void btnSource_Click(object sender, DirectEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.Url))
            {
                Uri url = new Uri(HttpContext.Current.Request.Url, this.Url);
                //switch (this.Syntax)
                //{
                //    case Syntax.Aspx:
                //        this.Window.Html = HighLighterUtils.AspxToHtml(url);
                //        break;
                //    case Syntax.CSharp:
                //        this.Window.Html = HighLighterUtils.CSharpToHtml(url);
                //        break;
                //    case Syntax.Xml:
                //        this.Window.Html = HighLighterUtils.XmlToHtml(url);
                //        break;
                //    case Syntax.JavaScript:
                //        this.Window.Html = HighLighterUtils.JsToHtml(url);
                //        break;
                //    default:
                //        throw new ArgumentOutOfRangeException();
                //}

                this.Window.Show();
            }
        }
    }

    public enum Syntax
    {
        Aspx,
        CSharp,
        Xml,
        JavaScript
    }
}