using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Form_FileUploadField.Controllers
{
    public class BasicController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UploadClick()
        {
            string tpl = "Uploaded file: {0}<br/>Size: {1} bytes";

            if (this.GetCmp<FileUploadField>("FileUploadField1").HasFile)
            {
                X.Msg.Show(new MessageBoxConfig
                {
                    Buttons = MessageBox.Button.OK,
                    Icon = MessageBox.Icon.INFO,
                    Title = "Success",
                    Message = string.Format(tpl, this.GetCmp<FileUploadField>("FileUploadField1").PostedFile.FileName, this.GetCmp<FileUploadField>("FileUploadField1").PostedFile.ContentLength)
                });
            }
            else
            {
                X.Msg.Show(new MessageBoxConfig
                {
                    Buttons = MessageBox.Button.OK,
                    Icon = MessageBox.Icon.ERROR,
                    Title = "Fail",
                    Message = "No file uploaded"
                });
            }
            DirectResult result = new DirectResult();
            result.IsUpload = true;
            return result;
        }
    }
}
