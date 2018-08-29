using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrainerConsultancy.ViewModel
{
    public class ProjectionViewModel
    {
        public int ProjectionID { get; set; }
        public int VendorID { get; set; }
        public int TrainerID { get; set; }
        public string ProjectFrom { get; set; }
        public string ProjectTo { get; set; }
        public SelectList TrainerList { get; set; }

    }
}