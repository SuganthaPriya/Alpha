using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainerConsultancy.ViewModel
{
    public class TrainerViewModel
    {
        public int TrainerID { get; set; }
        public string TrainerName { get; set; }
        public int? Experience { get; set; }
        public string Location { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}