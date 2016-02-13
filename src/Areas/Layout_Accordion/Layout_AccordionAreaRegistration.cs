using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Layout_Accordion
{
    public class Layout_AccordionAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Layout_Accordion";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Layout_Accordion_default",
                "Layout_Accordion/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
