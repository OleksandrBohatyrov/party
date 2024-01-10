using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace party.Models
{
    public class Guest
    {
        [Required(ErrorMessage = "Sisesta nimi")]

        public string Name { get; set; }
        [Required(ErrorMessage = "Sisesta posti adress siia")]
        [RegularExpression(@".+\@.+\..+", ErrorMessage ="Vale postkast")]
        public string Email { get; set; }
        [RegularExpression(@"\+372[0-9]{8}", ErrorMessage = "Vale number")]
        public string Phone { get; set; }
        public bool? WillAttend { get; set; }
        public string Notes { get; set; }
    }
}