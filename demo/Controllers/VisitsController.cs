using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using demo.Models;
using demo.Repositories.Interfaces;
using demo.ViewModels;
using demo.Services.Interfaces;

namespace demo.Controllers
{
    public class VisitsController : Controller
    {
         private readonly IVisitsService visitsService;

        public VisitsController(IVisitsService  visitsService)
        {
             this.visitsService = visitsService;
        }

        // GET: Visits
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult GetAllVisits([DataSourceRequest] DataSourceRequest request)
        {
            var visits = this.visitsService.GetAllPaginated(request.Page , request.PageSize);

            var result = visits.ToDataSourceResult(request);

            result.Total = visitsService.Count();
            result.Data = visits;
            return Json(result , JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public void CreateVisit(VisitViewModel visitViewModel)
        {

            this.visitsService.Add(visitViewModel);
        }


        [HttpDelete]
        public void DeleteVisit(int id)
        {
            this.visitsService.Delete(id);
        }

    }
}