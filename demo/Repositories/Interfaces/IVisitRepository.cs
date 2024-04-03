using demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.Repositories.Interfaces
{
    public interface IVisitRepository : IRepository<Visit, int>
    {
        IReadOnlyList<Visit> GetAllPaginated(int page, int pageSize);

       


    }
}
