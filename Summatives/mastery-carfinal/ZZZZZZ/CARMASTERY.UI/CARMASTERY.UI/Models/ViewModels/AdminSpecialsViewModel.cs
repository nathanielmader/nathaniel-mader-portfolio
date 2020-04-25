using CARMASTERY.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CARMASTERY.UI.Models.ViewModels
{
    public class AdminSpecialsViewModel
    {
        public Special NewSpecial { get; set; }
        public List<Special> SpecialsList { get; set; }
    }
}