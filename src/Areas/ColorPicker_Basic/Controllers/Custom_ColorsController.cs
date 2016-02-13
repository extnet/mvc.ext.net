using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.ColorPicker_Basic.Controllers
{
    public class Custom_ColorsController : Controller
    {
        public ActionResult Index()
        {
            string[] customColorsBlue = new string[256];
            string[] customColorsGreen = new string[256];

            for (int i = 0; i < 256; i++)
            {
                customColorsBlue[i] = i.ToString("X6");
                customColorsGreen[i] = (i << 8).ToString("X6");
            }
            this.ViewData["customColorsBlue"] = customColorsBlue;
            this.ViewData["customColorsGreen"] = customColorsGreen;

            return View();
        }

        public ActionResult ColorPalette2_Select(string value)
        {
            var colorPicker = X.GetCmp<ColorPicker>("ColorPalette2");
            colorPicker.AddScript(string.Format("setColor({0},\"{1}\");", colorPicker.ClientID, value));
            return this.Direct();
        }
    }
}
