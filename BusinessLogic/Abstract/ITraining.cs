using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface ITraining
    {
        IEnumerable<DataAccess.Models.Training> GetAll();
        DataAccess.Models.Training GetByID(DataAccess.Models.Training id);
        void Insert(DataAccess.Models.Training training);
        void Update(DataAccess.Models.Training obj);
        void Delete(object id);
        void Save();
    }
}
