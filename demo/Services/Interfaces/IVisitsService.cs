using demo.Models;
using demo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.Services.Interfaces
{
    public interface IVisitsService
    {
        IReadOnlyList<VisitViewModel> GetAllPaginated(int page , int pageSize);


        void Add(VisitViewModel visitViewModel );

        void Update(VisitViewModel visitViewModel);

        void Delete(int Id);
        int Count();

        IReadOnlyList<VisitType> GetAllVisitTypes();

        Visit GetById(int Id);
    }
}
