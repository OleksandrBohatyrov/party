using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace party.Models
{
    public class Peod
    {

      
        public int PeodId { get; set; }

        [Required(ErrorMessage = "Название праздника обязательно")]
        public string Name { get; set; }

        [Display(Name = "Дата проведения")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Дата проведения обязательна")]
        public DateTime Date { get; set; }
    }
}