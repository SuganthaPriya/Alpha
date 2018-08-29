using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainerConsultancy.Models;
using TrainerConsultancy.ViewModel;
using System.Data;
using System.Data.Entity;

namespace TrainerConsultancy.Controllers
{
    public class TrainerController : Controller
    {
        // GET: Trainer
        private TrainerConsultancyEntities trainerProjectionContext = new TrainerConsultancyEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TrainerViewModel trainerViewModel)
        {
            var trainerGrid = new List<TrainerViewModel>();
           // DateTime fromDate = Convert.ToDateTime(trainerViewModel.StartDate);
           // DateTime endDate = Convert.ToDateTime(trainerViewModel.EndDate);
            DateTime fromDate = DateTime.ParseExact(trainerViewModel.StartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(trainerViewModel.EndDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
           // using (var trainerProjectionContext = new TrainerConsultancyEntities())
           // {
                trainerGrid = (from t in trainerProjectionContext.Trainers
                                    where t.AvailableFrom <= fromDate & t.AvailableTo >= endDate
                                    select new TrainerViewModel()
                                    {
                                        TrainerID = t.TrainerID,
                                        TrainerName = t.TrainerName,
                                        Experience = t.Experience,
                                        Location = t.Location,
                                        StartDate= fromDate.ToString(),
                                        EndDate=endDate.ToString(),

                                    }).ToList();
            //}
            return View("TrainerGrid",trainerGrid);
        }
    }
}