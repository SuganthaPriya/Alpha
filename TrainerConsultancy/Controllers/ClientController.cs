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
    public class ClientController : Controller
    {
        private TrainerConsultancyEntities db = new TrainerConsultancyEntities();
        


        // GET: Client
        public ActionResult Index()
        {
           var trainerList = new SelectList(db.Trainers, "TrainerID", "TrainerName");
           /* var trainerList = db.Trainers.Select(x=>x.TrainerID).ToList();
            SelectList selectListItems = new SelectList;
            var trainerList = (from t in db.Trainers
                               select new ProjectionViewModel()
                               {
                                  TrainerID = t.TrainerID
                               }).ToList();*/

            var proj = new ProjectionViewModel();
            proj.TrainerList = trainerList;
            return View(proj);
        }

        [HttpPost]
        public ActionResult Index(ProjectionViewModel projectionViewModel)
        {
            return View();
        }
        public PartialViewResult CheckProjection(int id, string Sdate, string Edate)
        {
            bool result = false;
            DateTime fdate = DateTime.ParseExact(Sdate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime edate = DateTime.ParseExact(Edate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            using (var trainerProjectionContext = new TrainerConsultancyEntities())
            {
                var isNotProjectable = (from client in trainerProjectionContext.Projections
                                        where client.TrainerID == id &
                                        client.ProjectFrom <= fdate &
                                        client.ProjectTo >= edate
                                        select id).ToList();
                if (isNotProjectable.Count() == 1)
                    result = false;
                else
                    result = true;
            }
            ViewData["isNotProjectable"] = result;

            return PartialView("ProjectAlert");
        }
        public ActionResult CreateProjection(ProjectionViewModel projectionViewModel)
        {
            Projection projection = new Projection();
            projection.TrainerID = projectionViewModel.TrainerID;
            projection.VendorID = projectionViewModel.VendorID;
            projection.ProjectFrom = DateTime.ParseExact(projectionViewModel.ProjectFrom,"dd/MM/yyyy", CultureInfo.InvariantCulture);
            projection.ProjectTo = DateTime.ParseExact(projectionViewModel.ProjectTo, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //Sdate = Convert.ToDateTime(Sdate).ToString("dd/MM/yyyy");
            db.Projections.Add(projection);
            db.SaveChanges();
            return View();
        }
    }
}