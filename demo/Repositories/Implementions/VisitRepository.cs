using demo.Models;
using demo.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demo.Repositories.Implementions
{
    public class VisitRepository : Repository<Visit, int>, IVisitRepository
    {
        private readonly ApplicationDbContext db;

        public VisitRepository(ApplicationDbContext db) : base(db)
        {
            this.db = db;
        }

        public IReadOnlyList<Visit> GetAllPaginated(int page, int pageSize)
        {
            return db.visits.OrderBy(a => a.VisitId).Skip((page - 1) * pageSize).Take(pageSize).ToList();

        }
    }
}