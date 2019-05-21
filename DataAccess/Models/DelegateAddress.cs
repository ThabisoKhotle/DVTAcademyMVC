using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class DelegateAddress
    {
        [Key, Column(Order = 1)]
        public int AddressID { get; set; }
        [Key, Column(Order = 2)]
        public int DelegateID { get; set; }
        public virtual Delegate Delegate { get; set; }
        public virtual Address Address { get; set; }
    }
}
