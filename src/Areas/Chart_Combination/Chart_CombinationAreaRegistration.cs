using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Chart_Combination
{
    public class Chart_CombinationAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Chart_Combination";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Chart_Combination_default",
                "Chart_Combination/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
