using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Miscellaneous_Mouse_Distance_Sensor
{
    public class Miscellaneous_Mouse_Distance_SensorAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Miscellaneous_Mouse_Distance_Sensor";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Miscellaneous_Mouse_Distance_Sensor_default",
                "Miscellaneous_Mouse_Distance_Sensor/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
