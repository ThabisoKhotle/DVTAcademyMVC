using BusinessLogic.Abstract;
using DataAccess.GenericRespository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
     public class TrainingLogic : ITraining
    {
        private IGenericRepository<DataAccess.Models.Training> _repository;

        public TrainingLogic()
        {
            this._repository = new GenericRepository<DataAccess.Models.Training>();
        }
        public TrainingLogic(IGenericRepository<DataAccess.Models.Training> repository)
        {
            this._repository = repository;
        }

        public IEnumerable<DataAccess.Models.Training> GetAll()
        {
            return _repository.GetAll();
        }

        public DataAccess.Models.Training GetByID(DataAccess.Models.Training id)
        {
            return _repository.GetByID(id);
        }

        public void Insert(DataAccess.Models.Training training)
        {
            _repository.Insert(training);
            _repository.Save();
        }

        public void Update(DataAccess.Models.Training obj)
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
