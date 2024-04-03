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
        private readonly IVisitTypeRepository visitTypeRepository;
 
        public VisitsService(IVisitRepository visitRepository  , IVisitTypeRepository visitTypeRepository  )
        {
             this.visitRepository = visitRepository;
            this.visitTypeRepository = visitTypeRepository;
         
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

        public IReadOnlyList<VisitViewModel> GetAllPaginated(int page ,int pageSize)
        {
            var visits = visitRepository.GetAllPaginated(page, pageSize).Select(a => new VisitViewModel {
                VisitId = a.VisitId,
                     Title = a.Title,
                From = a.From,
                To = a.To,
                NumberOfDays = a.NumberOfDays,
                Notes = a.Notes,
                VisitType = a.VisitType.Name,
                

            }).ToList();


            return visits;
        }

        public int Count()
        {
            return visitRepository.Count();

        }

        public IReadOnlyList<VisitType> GetAllVisitTypes()
        {
            return visitTypeRepository.GetAllPaginated(1, 500);
        }

        public void Update(VisitViewModel visitViewModel)
        {
            var visitFromDb = visitRepository.GetByid(visitViewModel.VisitId);
            visitFromDb.Title = visitViewModel.Title;
            visitFromDb.From = visitViewModel.From;
            visitFromDb.To = visitViewModel.To;
            visitFromDb.VisitTypeId = visitViewModel.VisitTypeId;
            visitFromDb.Notes = visitViewModel.Notes;
            visitFromDb.NumberOfDays = visitViewModel.NumberOfDays;
             visitRepository.Update(visitFromDb);


                }

        public Visit GetById(int Id)
        {
            return visitRepository.GetByid(Id);
        }
    }
}