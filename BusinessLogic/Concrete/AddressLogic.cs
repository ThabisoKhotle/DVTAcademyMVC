using DataAccess.GenericRespository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
    public class AddressLogic
    {
        private IGenericRepository<DataAccess.Models.Address> repository = null;

        public IEnumerable<DataAccess.Models.Address> GetAll()
        {
            return repository.GetAll();
        }

        public DataAccess.Models.Address GetByID(DataAccess.Models.Address id)
        {
            return repository.GetByID(id);
        }

        public void Insert(DataAccess.Models.Address course)
        {
            repository.Insert(course);
        }

        public void Update(DataAccess.Models.Address obj)
        {
            repository.Update(obj);
        }

        public void Delete(DataAccess.Models.Address id)
        {
            repository.Delete(id);
        }

        public void Save()
        {
            repository.Save();
        }
    }
}
