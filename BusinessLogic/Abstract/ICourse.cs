using BusinessLogic.Concrete;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface ICourse
    {
        IEnumerable<DataAccess.Models.Course> GetAll();
        //DataAccess.Models.Course GetByID(DataAccess.Models.Course id);
        void Insert(DataAccess.Models.Course course);
        void Update(DataAccess.Models.Course obj);
        void Delete(object id);
        void Save();
        Course GetByID(object courseID);
    }
}
