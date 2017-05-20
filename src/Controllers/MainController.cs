using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace Ext.Net.MVC.Examples
{
    [DirectController]
    public class MainController : System.Web.Mvc.Controller
    {
        public ActionResult Index()
        {
            if (this.Request.QueryString.Get("clearExamplesCache") != null)
            {
                ExamplesModel.ClearExamplesTree();
                X.Msg.Alert("Cache clear", "Tree nodes cache cleared.").Show();
            }
            return View();
        }

        public ActionResult Home()
        {
            return View();
        }

        [OutputCache(Duration = 3600)]
        public ActionResult GetExamplesNodes(string node)
        {
            if (node == "Root")
            {
                return this.Content(ExamplesModel.GetExamplesNodes().ToJson());
            }

            return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest);
        }

        [DirectMethod]
        [OutputCache(Duration=86400, VaryByParam="theme")]
        public DirectResult SetTheme(string theme)
        {
            if (theme == "Blue")
            {
                theme = "Default";
            }

            theme = theme.Replace(" ", "");
            this.Session["Ext.Net.Theme"] = (Theme)Enum.Parse(typeof(Theme), theme);

            return this.Direct();
        }

        [DirectMethod]
        [OutputCache(Duration = 86400, VaryByParam = "name")]
        public DirectResult GetHashCode(string name)
        {
            return this.Direct(Math.Abs(name.ToLower().GetHashCode()));
        }

        [DirectMethod]
        public DirectResult ChangeScriptMode(bool debug)
        {
            if (debug)
            {
                this.Session["Ext.Net.ScriptMode"] = Ext.Net.ScriptMode.Debug;
                this.Session["Ext.Net.SourceFormatting"] = true;
            }
            else
            {
                this.Session["Ext.Net.ScriptMode"] = Ext.Net.ScriptMode.Release;
                this.Session["Ext.Net.SourceFormatting"] = false;
            }

            //Response.Redirect(""); // GitHub #823: Although this works on WebForms, triggers 'header sent after headers processed' error on MVC.

            X.AddScript("location.reload();");

            return this.Direct();
        }
    }
}
