using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Chart_Misc
{
    public class Chart_MiscAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return areaName;
            }
        }

        // Will trim out this text from the class name while querying the area name.
        private static readonly string compulsoryClassName = "AreaRegistration";

        private string areaName
        {
            get
            {
                var className = this.GetType().Name;
                var areaName = className;

                if (className.EndsWith(compulsoryClassName))
                {
                    areaName = className.Remove(className.Length - compulsoryClassName.Length);
                }

                return areaName;
            }
        }
        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                areaName + "_default",
                areaName + "/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
