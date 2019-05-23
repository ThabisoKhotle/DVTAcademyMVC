using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class AddressType
    {
        [Key]
        public int ID { get; set; }
        public string Type { get; set; }
    }
}
