using DataAccess.GenericRespository;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
    public class CourseTrainingLogic
    {
        private IGenericRepository<CourseTraining> _repository = null;

        public IEnumerable<CourseTraining> GetAll()
        {
            return _repository.GetAll();
        }

        public CourseTraining GetByID(CourseTraining id)
        {
            return _repository.GetByID(id);
        }

        public void Insert(CourseTraining course)
        {
            _repository.Insert(course);
        }

        public void Update(CourseTraining obj)
        {
            _repository.Update(obj);
        }

        public void Delete(CourseTraining id)
        {
            _repository.Delete(id);
        }

        public void Save()
        {
            _repository.Save();
        }
    }
}
