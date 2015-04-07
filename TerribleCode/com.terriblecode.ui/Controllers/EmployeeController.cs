using System.Net;
using System.Web.Mvc;

using com.terriblecode.businesslayer;
using com.terriblecode.dal;

namespace com.terriblecode.ui.Controllers
{
    public class EmployeeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return Json(
                EmployeeService.Instance.List(),
                JsonRequestBehavior.AllowGet);
        }

        public ActionResult Get(int id)
        {
            return Json(
                EmployeeService.Instance.GetById(id),
                JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Index(Employee employee)
        {
            return Json(
                EmployeeService.Instance.Save(employee),
                JsonRequestBehavior.DenyGet);
        }

        [HttpPatch]
        public ActionResult Update(Employee employee)
        {
            EmployeeService.Instance.Update(employee);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}