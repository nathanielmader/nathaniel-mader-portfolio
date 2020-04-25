using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARMASTERY.Models.DataModels
{
    public class Special
    {
        public int SpecialId { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string SpecialTitle { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string SpecialDescription { get; set; }
    }
}
