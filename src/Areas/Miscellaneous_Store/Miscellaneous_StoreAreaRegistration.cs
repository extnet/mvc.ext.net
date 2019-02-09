using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Miscellaneous_Store
{
    public class Miscellaneous_StoreAreaRegistration : AreaRegistration
    {
        private string areaName;

        public override string AreaName
        {
            get
            {
                if (areaName == null)
                {
                    areaName = ExampleAreaRegistration.ParseAreaName(GetType());
                }

                return areaName;
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            ExampleAreaRegistration.RegisterArea(context, AreaName);
        }
    }
}
