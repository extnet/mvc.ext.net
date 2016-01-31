using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ext.Net.MVC;
using Ext.Net.MVC.Examples.Areas.Form_Groups.Models;

namespace Ext.Net.MVC.Examples.Areas.Form_Groups.Controllers
{
    public class GroupForController : Controller
    {
        //
        // GET: /Form_Groups/GroupFor/

        public ActionResult Index()
        {
            return View(new GroupForModel
            {
                Enums = new EnumModel
                {
                    Borders = Border.Top | Border.Left,
                    Sex = Sex.Male
                },

                Strings = new StringModel
                {
                    Borders = "Top,Left",
                    Sex = "Male"
                }
            });
        }

        public FormPanelResult SubmitEnums([Bind(Prefix = "Enums.Borders")]Border[] borders, [Bind(Prefix = "Enums.Sex")]Sex sex)
        {
            X.Msg.Alert("Values", string.Format("Borders: {0}, <br/>Sex: {1}", string.Join(", ", borders.Select(b => b.ToString())), sex)).Show();
            return this.FormPanel();
        }

        public FormPanelResult SubmitStrings([Bind(Prefix = "Strings.Borders")]string[] borders, [Bind(Prefix = "Strings.Sex")]string sex)
        {
            X.Msg.Alert("Values", string.Format("Borders: {0}, <br/>Sex: {1}", string.Join(", ", borders), sex)).Show();
            return this.FormPanel();
        }
    }
}
