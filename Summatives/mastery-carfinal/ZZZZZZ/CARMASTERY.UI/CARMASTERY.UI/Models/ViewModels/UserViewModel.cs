using CARMASTERY.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CARMASTERY.UI.Models.ViewModels
{
    public class UserViewModel
    {
        public User User { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public List<SelectListItem> RolesList { get; set; }

        public UserViewModel()
        {
            RolesList = new List<SelectListItem>();
        }

        public void SetRoles(IEnumerable<Role> roles)
        {
            foreach (var role in roles)
            {
                RolesList.Add(new SelectListItem()
                {
                    Value = role.RoleId.ToString(),
                    Text = role.RoleDescription
                });
            }
        }
    }
}