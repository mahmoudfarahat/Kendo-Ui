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

     

        //[HttpGet]
        //public ActionResult Create()
        //{
        //    return PartialView("_EditModal", new Visit());
        //}


        [HttpPost]
        public ActionResult Create(VisitViewModel visitViewModel)
        {
            if (ModelState.IsValid)
            {
                this.visitsService.Add(visitViewModel);

                return View();
            }
            else
            {
                return PartialView("_EditModal", visitViewModel);
            }
        }


        [HttpGet]
        [Route("visits/{Id}")]
        public ActionResult AddEdit(int? Id)
        {
            VisitViewModel Model;
            if (Id.HasValue)
            {
                var modelFromDb = this.visitsService.GetById(Id.Value);
                Model = new VisitViewModel
                {
                    Title= modelFromDb.Title,
                    Notes = modelFromDb.Notes,
                    From = modelFromDb.From,
                    To = modelFromDb.To,
                    VisitTypeId = modelFromDb.VisitTypeId,
                    NumberOfDays = modelFromDb.NumberOfDays
                };
            }
            else
            {
                Model = new VisitViewModel();
            }
            return PartialView("_EditModal", Model);
        }



        [HttpPut]
        public void Edit(VisitViewModel visitViewModel)
        {
            if (this.ModelState.IsValid)
            {
                this.visitsService.Update(visitViewModel);
            }



        }






        [HttpDelete]
        public void DeleteVisit(int id)
        {
            this.visitsService.Delete(id);
        }


        [HttpGet]
        public ActionResult GetAllVisitType()
        {
            var result = this.visitsService.GetAllVisitTypes();

            return Json(result, JsonRequestBehavior.AllowGet);

        }

    }
}