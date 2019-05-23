using BusinessLogic.Abstract;
using DataAccess.GenericRespository;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
     public class CourseLogic : ICourse
    {
        private IGenericRepository<Course> _repository;

        public CourseLogic()
        {
            this._repository = new GenericRepository<Course>();
        }
        public CourseLogic(IGenericRepository<Course> repository)
        {
            this._repository = repository;
        }
        public IEnumerable<Course> GetAll()
        {
            return _repository.GetAll();
        }

        public Course GetByID(object id)
        {
            return _repository.GetByID(id);
        }

        public void Insert(Course course)
        {
            _repository.Insert(course);
            _repository.Save();
        }

        public void Update(Course obj)
        {
            _repository.Update(obj);
            _repository.Save();
        }

        public void Delete(object id)
        {
            _repository.Delete(id);
            _repository.Save();
        }

        public void Save()
        {
            _repository.Save();
        }
    }
}
