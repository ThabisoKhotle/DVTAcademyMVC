using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Address
    {
        [Key]
        public int ID { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public int PostCode { get; set; }
        public int AddressTypeID { get; set; }
        public virtual AddressType AddressType { get; set; }
    }
}

