using demo.Models;
using demo.Repositories.Interfaces;
using demo.Services.Interfaces;
using demo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demo.Services.Implementions
{
    public class VisitsService : IVisitsService
    {
        private readonly IVisitRepository visitRepository;

        public VisitsService(IVisitRepository visitRepository )
        {
             this.visitRepository = visitRepository;
        }

        public void Add(VisitViewModel visitViewModel)
        {
            var newVisit = new Visit
            {
                Title = visitViewModel.Title,
                From = visitViewModel.From,
                To = visitViewModel.To,
                VisitTypeId = visitViewModel.VisitTypeId,
                Notes = visitViewModel.Notes,
                NumberOfDays = visitViewModel.NumberOfDays
            };

            visitRepository.Add(newVisit);
           
        }

        public void Delete(int Id)
        {
            visitRepository.Delete(Id);

                }

        public IReadOnlyList<Visit> GetAllPaginated(int page ,int pageSize)
        {
            var visits = visitRepository.GetAllPaginated(page, pageSize).ToList();


            return visits;
        }

        public int Count()
        {
            return visitRepository.Count();

        }
    }
}