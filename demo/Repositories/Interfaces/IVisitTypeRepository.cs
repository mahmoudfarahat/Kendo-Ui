using demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demo.Repositories.Interfaces
{
    public interface IVisitTypeRepository : IRepository<VisitType, int>
    {

        IReadOnlyList<VisitType> GetAllPaginated(int page, int pageSize);

    }
}