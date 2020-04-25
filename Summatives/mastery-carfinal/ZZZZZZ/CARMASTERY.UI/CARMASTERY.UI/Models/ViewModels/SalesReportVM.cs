using CARMASTERY.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CARMASTERY.UI.Models.ViewModels
{
    public class SalesReportVM
    {
        public List<SelectListItem> UserList { get; set; }

        public SalesReportVM()
        {
            UserList = new List<SelectListItem>();
        }
        public void SetUsers(IEnumerable<User> users)
        {
            foreach (var user in users)
            {
                UserList.Add(new SelectListItem()
                {
                    Value = user.UserId.ToString(),
                    Text = user.LastName
                });
            }
        }
    }
}