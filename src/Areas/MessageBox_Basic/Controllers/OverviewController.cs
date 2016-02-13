using System;
using System.Threading;
using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.MessageBox_Basic.Controllers
{
    public class OverviewController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Button1_Click()
        {
           X.Msg.Confirm("Confirm", "Are you sure you want to do that?", new JFunction { Fn = "showResult" }).Show();

            return this.Direct();
        }

        public ActionResult Button2_Click()
        {
           X.Msg.Prompt("Name", "Please enter your name:", new JFunction { Fn = "showResultText" }).Show();

            return this.Direct();
        }

        public ActionResult Button3_Click()
        {
           X.Msg.Show(new MessageBoxConfig
            {
                Title = "Address",
                Message = "Please enter your address:",
                Width = 300,
                Buttons = MessageBox.Button.OKCANCEL,
                Multiline = true,
                AnimEl = this.GetCmp<Button>("Button3").ClientID,
                Fn = new JFunction { Fn = "showResultText" }
            });

            return this.Direct();
        }

        public ActionResult Button4_Click()
        {
           X.Msg.Show(new MessageBoxConfig
            {
                Title = "Save Changes?",
                Message = "You are closing a tab that has unsaved changes. <br />Would you like to save your changes?",
                Buttons = MessageBox.Button.YESNOCANCEL,
                Icon = MessageBox.Icon.QUESTION,
                Fn = new JFunction { Fn = "showResult" },
                AnimEl = this.GetCmp<Button>("Button4").ClientID
            });

            return this.Direct();
        }

        public ActionResult Button5_Click()
        {
           X.Msg.Show(new MessageBoxConfig
            {
                Title = "Please wait",
                Message = "Loading items...",
                ProgressText = "Initializing...",
                Width = 300,
                Progress = true,
                Closable = false,
                AnimEl = this.GetCmp<Button>("Button5").ClientID
            });

            StartLongAction();

            return this.Direct();
        }

        public ActionResult Button6_Click()
        {
           X.Msg.Show(new MessageBoxConfig
            {
                Message = "Saving your data, please wait...",
                ProgressText = "Saving...",
                Width = 300,
                Wait = true,
                WaitConfig = new WaitConfig { Interval = 200 },
                IconCls = "ext-mb-download",
                AnimEl = this.GetCmp<Button>("Button6").ClientID
            });

            X.AddScript("setTimeout(function () { Ext.MessageBox.hide(); Ext.Msg.notify('Done', 'Your data was saved!'); }, 8000);");

            return this.Direct();
        }

        public ActionResult Button7_Click()
        {
            X.Msg.Alert("Status", "Changes saved successfully.", new JFunction { Fn = "showResult" }).Show();

            return this.Direct();
        }

        public ActionResult Button8_Click(string icon)
        {
           X.Msg.Show(new MessageBoxConfig
            {
                Title = "Icon Support",
                Message = "Message with an Icon",
                Buttons = MessageBox.Button.OK,
                Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), icon),
                AnimEl = this.GetCmp<Button>("Button8").ClientID,
                Fn = new JFunction { Fn = "showResult" }
            });

            return this.Direct();
        }

        private void StartLongAction()
        {
            HttpContext.Cache["Task1"] = 0;
            ThreadPool.QueueUserWorkItem(LongAction);

            this.GetCmp<TaskManager>("TaskManager1").StartTask("Task1");
        }

        private void LongAction(object state)
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);
                HttpContext.Cache["Task1"] = i + 1;
            }
            HttpContext.Cache.Remove("Task1");
        }

        public ActionResult RefreshProgress()
        {
            object progress = HttpContext.Cache["Task1"];
            if (progress != null)
            {
               X.Msg.UpdateProgress(((int)progress) / 10f, string.Format("Step {0} of {1}...", progress, 10));
            }
            else
            {
                this.GetCmp<TaskManager>("TaskManager1").StopTask("Task1");
                X.MessageBox.Hide();
                X.AddScript("Ext.Msg.notify('Done', 'Your items were loaded!');");
            }

            return this.Direct();
        }
    }
}
