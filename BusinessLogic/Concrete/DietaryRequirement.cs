using DataAccess.GenericRespository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
    class DietaryRequirement
    {
        private IGenericRepository<DietaryRequirement> _repository = null;

        public IEnumerable<DietaryRequirement> GetAll()
        {
            return _repository.GetAll();
        }

        public DietaryRequirement GetByID(DietaryRequirement id)
        {
            return _repository.GetByID(id);
        }

        public void Insert(DietaryRequirement course)
        {
            _repository.Insert(course);
        }

        public void Update(DietaryRequirement obj)
        {
            _repository.Update(obj);
        }

        public void Delete(DietaryRequirement id)
        {
            _repository.Delete(id);
        }

        public void Save()
        {
            _repository.Save();
        }
    }
}

