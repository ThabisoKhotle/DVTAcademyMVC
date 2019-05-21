using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DVTAcademyMVC.Models
{
    public class Training
    {
        [Required]
        public int ID { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [Required]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
        [Required]
        public decimal Cost { get; set; }
        [Required]
        [Display(Name = "Registration Closing Date")]
        public DateTime RegistrationClosingDate { get; set; }

        public int VenueID { get; set; }
        [Required]
        public Venue Venue { get; set; }
    }
}