using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ext.Net.MVC.Examples.Areas.GridPanel_Update.Models.Restful;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_Update.Controllers
{
    public class RestfulController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]        
        public RestResult Create(TestPerson person)
        {
            try
            {
                TestPerson.AddPerson(person);

                return new RestResult
                {
                    Success = true,
                    Message = "New person is added",
                    Data = person
                };
            }
            catch (Exception e)
            {
                return new RestResult
                {
                    Success = false,
                    Message = e.Message
                };
            }
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public RestResult Read()
        {
            try
            {
                return new RestResult
                {
                    Success = true,
                    Data = TestPerson.TestData
                };
            }
            catch (Exception e)
            {
                return new RestResult
                {
                    Success = false,
                    Message = e.Message
                };
            }
        }

        [AcceptVerbs(HttpVerbs.Put)]
        public RestResult Update(TestPerson person)
        {
            try
            {
                TestPerson.UpdatePerson(person);

                return new RestResult
                {
                    Success = true,
                    Message = "Person has been updated"
                };
            }
            catch (Exception e)
            {
                return new RestResult
                {
                    Success = false,
                    Message = e.Message
                };
            }
        }

        [AcceptVerbs(HttpVerbs.Delete)]
        public RestResult Destroy(int id)
        {
            try
            {
                TestPerson.DeletePerson(id);

                return new RestResult
                {
                    Success = true,
                    Message = "Person has been deleted"
                };
            }
            catch (Exception e)
            {
                return new RestResult
                {
                    Success = false,
                    Message = e.Message
                };
            }
        }
    }
}
