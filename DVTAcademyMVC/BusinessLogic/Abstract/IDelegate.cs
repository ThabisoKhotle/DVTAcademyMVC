using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IDelegate
    {
        IEnumerable<Delegate> GetAll();
        DataAccess.Models.Delegate GetByID(DataAccess.Models.Delegate id);
        void Insert(DataAccess.Models.Delegate @delegate);
        void Update(DataAccess.Models.Delegate obj);
        void Delete(DataAccess.Models.Delegate id);
        void Save();
    }
}
