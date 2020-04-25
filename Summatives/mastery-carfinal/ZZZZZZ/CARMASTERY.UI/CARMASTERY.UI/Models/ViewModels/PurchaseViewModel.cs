using CARMASTERY.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CARMASTERY.UI.Models.ViewModels
{
    public class PurchaseViewModel
    {
        //public PurchaseViewModel()
        //{
        //    this.Vehicle = new Vehicle();
        //}
        public Vehicle Vehicle { get; set; }
        public Purchase Purchase { get; set; }
        public List<SelectListItem> PurchaseTypeList { get; set; }
        public List<SelectListItem> StatesList { get; set; }

        public PurchaseViewModel()
        {
            PurchaseTypeList = new List<SelectListItem>();
            StatesList = new List<SelectListItem>();
            //this.Vehicle = new Vehicle();
        }

        public void SetPurchaseTypes(IEnumerable<PurchaseType> purchaseTypes)
        {
            foreach (var type in purchaseTypes)
            {
                PurchaseTypeList.Add(new SelectListItem()
                {
                    Value = type.PurchaseTypeId.ToString(),
                    Text = type.PurchaseTypeDescription
                });
            }
        }

        public void SetStates(IEnumerable<State> states)
        {
            foreach (var state in states)
            {
                StatesList.Add(new SelectListItem()
                {
                    Value = state.StateId.ToString(),
                    Text = state.StateAB
                });
            }
        }
    }
}