using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_Data_Presentation
{
    public class GridPanel_Data_PresentationAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "GridPanel_Data_Presentation";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "GridPanel_Data_Presentation_default",
                "GridPanel_Data_Presentation/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
