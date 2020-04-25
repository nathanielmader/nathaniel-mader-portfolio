using CARMASTERY.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CARMASTERY.UI.Models.ViewModels
{
    public class AddModelViewModel
    {
        public Model Model { get; set; }
        public List<SelectListItem> MakesList { get; set; }

        public AddModelViewModel()
        {
            Model = new Model();
            MakesList = new List<SelectListItem>();
        }

        public void SetMakesList(IEnumerable<Make> makes)
        {
            foreach (var make in makes)
            {
                MakesList.Add(new SelectListItem()
                {
                    Value = make.MakeId.ToString(),
                    Text = make.MakeDescription,
                });
            }
        }
    }
}