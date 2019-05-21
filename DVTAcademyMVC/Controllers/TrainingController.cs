using DataAccess.GenericRespository;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using BusinessLogic.Abstract;

namespace DVTAcademyMVC.Controllers
{
    public class TrainingController : Controller
    {
        private IGenericRepository<Training> TrainingRepository = null;

        public TrainingController()
        {
            this.TrainingRepository = new GenericRepository<Training>();
        }

        //public TrainingController(IGenericRepository<Training> TrainingRepository)
        //{
        //    this.TrainingRepository = TrainingRepository;
        //}

        private readonly ITraining _training;
        public TrainingController(ITraining training)
        {
            this._training = training;
        }

        [HttpGet]
        public ActionResult Index(int page = 1, int pagesize = 5)
        {
            //var training = TrainingRepository.GetAll();
            //return View(training); //training);

            var training = _training.GetAll().ToList();
            PagedList<Training> trainingmodel = new PagedList<Training>(training, page, pagesize);
            return View(trainingmodel);
        }

        [HttpGet]
        public ActionResult InsertTraining()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertTraining(Training training)
        {
            if (ModelState.IsValid)
            {
                TrainingRepository.Insert(training);
                TrainingRepository.Save();
                return RedirectToAction("Index", "Training");
            }
            return View();
        }

        [HttpGet]
        public ActionResult UpdateTraining(int id)
        {
            Training training = TrainingRepository.GetByID(id);
            return View(training);// training);
        }

        [HttpPost]
        public ActionResult UpdateTraining(Training training)
        {
            if (ModelState.IsValid)
            {
                TrainingRepository.Update(training);
                return RedirectToAction("Index", "Training");
            }
            else
            {
                return View("UpdateTraining", training.ID);
            }
        }

        [HttpGet]
        public ActionResult DeleteTrainig(int id)
        {
            Training training = TrainingRepository.GetByID(id);
            return View(training);// training);
        }

        [HttpPost]
        public ActionResult DeleteTraining(Training training)
        {
            TrainingRepository.Delete(training.ID);
            return RedirectToAction("Index", "Training");
        }

    }

}