using demo.Models;
using demo.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demo.Repositories.Implementions
{
    public class VisitTypeRepository : Repository<VisitType, int>, IVisitTypeRepository
    {
        private readonly ApplicationDbContext db;

        public VisitTypeRepository(ApplicationDbContext db) : base(db)
        {
            this.db = db;
        }

        public IReadOnlyList<VisitType> GetAllPaginated(int page, int pageSize)
        {
             return db.VisitTypes.OrderBy(a => a.Id).Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}