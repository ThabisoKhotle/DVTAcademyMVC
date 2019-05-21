using BusinessLogic.Abstract;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class TrainingController : ApiController
    {
        private readonly ITraining training;
        public TrainingController(ITraining training)
        {
            this.training = training;
        }

        public IEnumerable<Training> Get()
        {
            //ITraining training = new TrainingLogic();

            List<Training> entityTrainingList = training.GetAll().ToList();
            List<Training> modelTrainingList = new List<Training>();
            foreach (Training item in entityTrainingList)
            {
                modelTrainingList.Add(new Training
                {
                    ID = item.ID,
                    StartDate = item.StartDate,
                    EndDate = item.EndDate,
                    Cost = item.Cost,
                    RegistrationClosingDate = item.RegistrationClosingDate,
                    Venue = item.Venue
                });
            }
            return modelTrainingList;
        }

        public IHttpActionResult Post([FromBody]Training item)
        {
            try
            {
                training.Insert(new Training { ID = item.ID, StartDate = item.StartDate, EndDate = item.EndDate,
                RegistrationClosingDate = item.RegistrationClosingDate, Cost = item.Cost, VenueID = item.VenueID });
                return Redirect("Index");

            }
            catch
            {
                return Ok();
            }
        }

        public IHttpActionResult Delete(Training item)
        {
            try
            {
                training.Delete(item.ID);
                training.Save();
                return Redirect("Index");
            }
            catch
            {
                return Ok();
            }
        }

        public IHttpActionResult Put(Training item)
        {
            try
            {
                training.Update(new Training { ID = item.ID, StartDate = item.StartDate, EndDate = item.EndDate,
                Cost = item.Cost, RegistrationClosingDate = item.RegistrationClosingDate, VenueID = item.VenueID });
                return Redirect("Index");
            }
            catch
            {
                return Ok();
            }
        }
    }
}

