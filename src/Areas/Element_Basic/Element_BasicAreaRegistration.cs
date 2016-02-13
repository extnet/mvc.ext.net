using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Element_Basic
{
    public class Element_BasicAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Element_Basic";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Element_Basic_default",
                "Element_Basic/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
