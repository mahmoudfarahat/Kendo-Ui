using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demo.Models
{
    public class Visit
    {
        public int VisitId { get; set; }

        public string Title { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public int NumberOfDays { get; set; }

        public string Notes { get; set; }

        public int VisitTypeId { get; set; }

        public VisitType VisitType { get; set; }

    }
}