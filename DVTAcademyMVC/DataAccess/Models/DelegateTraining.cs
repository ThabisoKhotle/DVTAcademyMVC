using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class DelegateTraining
    {
        [Key, Column(Order = 1)]
        public int DelegateID { get; set; }
        [Key, Column(Order = 2)]
        public int TrainingsID { get; set; }
        public Delegate Delegate { get; set; }
        public Training Trainings { get; set; }
    }
}
