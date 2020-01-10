using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Ext.Net.MVC.Examples.Areas.Associations_HasOne.Models;

namespace Ext.Net.MVC.Examples.Areas.Associations_HasOne.Controllers
{
    [DirectController(AreaName = "Associations_HasOne", GenerateProxyForOtherAreas = false, GenerateProxyForOtherControllers = false, IDMode = DirectMethodProxyIDMode.None)]
    public class Simple_Lazy_LoadController : Controller
    {
        class query
        {
            public int id { get; set; }
        }

        [DirectMethod(ShowMask = true, CustomTarget = "#{AddressPanel}")]
        public ActionResult GetAddress(string action, string paramsJson)
        {
            var extraParams = JsonConvert.DeserializeObject<query>(paramsJson);
            return this.Direct(new List<Address>()
            {
                new Address(1, "1", "Cross Street 11/1", "Big City", "123456" ),
                new Address(2, "2", "Cross Street 12/2", "Big City", "654321" ),
                new Address(3, "3", "Cross Street 13/3", "Big City", "321654" )
            }.Where(match => match.Id == extraParams.id));
        }

        public ActionResult Index()
        {
            return View(new List<Simple_Lazy_Load.Person>
            {
                new Simple_Lazy_Load.Person(1, "John Smith", 1 ),
                new Simple_Lazy_Load.Person(2, "Jane Brown", 2 ),
                new Simple_Lazy_Load.Person(3, "Kevin Jones", 3 )
            });
        }
    }
}
