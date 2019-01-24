using System.Web.Mvc;

namespace Ext.Net.MVC.Examples.Areas.Kitchen_Sink_GridPanels.Controllers
{
    public class PropertyController : Controller
    {
        private PropertyGrid propertyGrid
        {
            get
            {
                return X.GetCmp<PropertyGrid>("PropertyGrid1");
            }
        }

        public ActionResult Index()
        {
            return View(Models.Grouped_HeaderModel.GetData());
        }

        public ActionResult UpdateSource_Click()
        {
            var updatedGridData = Models.PropertyModel.GetUpdatedPropData();
            propertyGrid.SetSource(updatedGridData, true);

            return this.Direct();
        }

        public ActionResult NewDataSource_Click()
        {
            var newGridData = Models.PropertyModel.GetNewPropData();

            propertyGrid.SetSource(newGridData, true);

            return this.Direct();
        }
    }
}
