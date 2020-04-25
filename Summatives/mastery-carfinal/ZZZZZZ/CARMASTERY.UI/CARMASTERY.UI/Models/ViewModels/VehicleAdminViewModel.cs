using CARMASTERY.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CARMASTERY.UI.Models.ViewModels
{
    public class VehicleAdminViewModel
    {
        public Vehicle Vehicle { get; set; }
        public HttpPostedFileBase ImageUpload { get; set; }

        public List<SelectListItem> VehicleMakesList { get; set; }
        public List<SelectListItem> VehicleModelsList { get; set; }
        public List<SelectListItem> VehicleTypesList { get; set; }
        public List<SelectListItem> BodyStylesList { get; set; }
        public List<SelectListItem> TransmissionsList { get; set; }
        public List<SelectListItem> ExteriorColorsList { get; set; }
        public List<SelectListItem> InteriorColorsList { get; set; }

        public VehicleAdminViewModel()
        {
            VehicleMakesList = new List<SelectListItem>();
            VehicleModelsList = new List<SelectListItem>();
            VehicleTypesList = new List<SelectListItem>();
            BodyStylesList = new List<SelectListItem>();
            TransmissionsList = new List<SelectListItem>();
            ExteriorColorsList = new List<SelectListItem>();
            InteriorColorsList = new List<SelectListItem>();
        }

        public void SetMakes(IEnumerable<Make> makes)
        {
            foreach (var make in makes)
            {
                VehicleMakesList.Add(new SelectListItem()
                {
                    Value = make.MakeId.ToString(),
                    Text = make.MakeDescription
                });
            }
        }

        public void SetModels(IEnumerable<Model> models)
        {
            foreach (var model in models)
            {
                VehicleModelsList.Add(new SelectListItem()
                {
                    Value = model.ModelId.ToString(),
                    Text = model.ModelDescription
                });
            }
        }

        public void SetTypes(IEnumerable<VehicleType> types)
        {
            foreach (var type in types)
            {
                VehicleTypesList.Add(new SelectListItem()
                {
                    Value = type.VehicleTypeId.ToString(),
                    Text = type.TypeDescription
                });
            }
        }

        public void SetBodyStyles(IEnumerable<BodyStyle> bodyStyles)
        {
            foreach (var bodyStyle in bodyStyles)
            {
                BodyStylesList.Add(new SelectListItem()
                {
                    Value = bodyStyle.BodyStyleId.ToString(),
                    Text = bodyStyle.BodyStyleDescription
                });
            }
        }

        public void SetTransmissions(IEnumerable<Transmission> transmissions)
        {
            foreach (var transmission in transmissions)
            {
                TransmissionsList.Add(new SelectListItem()
                {
                    Value = transmission.TransmissionId.ToString(),
                    Text = transmission.TransmissionType
                });
            }
        }

        public void SetExteriorColors(IEnumerable<ExteriorColor> exteriorColors)
        {
            foreach (var exteriorColor in exteriorColors)
            {
                ExteriorColorsList.Add(new SelectListItem()
                {
                    Value = exteriorColor.ExteriorColorId.ToString(),
                    Text = exteriorColor.ExteriorColorDescription
                });
            }
        }

        public void SetInteriorColors(IEnumerable<InteriorColor> interiorColors)
        {
            foreach (var interiorColor in interiorColors)
            {
                InteriorColorsList.Add(new SelectListItem()
                {
                    Value = interiorColor.InteriorColorId.ToString(),
                    Text = interiorColor.InteriorColorDescription
                });
            }
        }
    }
}