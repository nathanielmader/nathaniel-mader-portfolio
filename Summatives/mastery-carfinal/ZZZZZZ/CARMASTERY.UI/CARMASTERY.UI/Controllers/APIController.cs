using CARMASTERY.Data;
using CARMASTERY.Models.DataModels;
using CARMASTERY.Models.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CARMASTERY.UI.Controllers
{
    public class APIController : ApiController
    {
        //For Used Inventory Controller Search
        [Route("api/search/searchusedvehicles")]
        [AcceptVerbs("GET")]
        public IHttpActionResult SearchUsedVehicles(string input, decimal? minPrice, decimal? maxPrice, int? minYear, int? maxYear)
        {

            var repo = CarMasterRepoFactory.Create();
            try
            {
                var parameters = new SearchViewModel()
                {
                    Input = input,
                    MinPrice = minPrice,
                    MaxPrice = maxPrice,
                    MinYear = minYear,
                    MaxYear = maxYear
                };

                var result = repo.SearchUsedVehicles(parameters);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //For New Inventory Controller Search
        [Route("api/search/searchnewvehicles")]
        [AcceptVerbs("GET")]
        public IHttpActionResult SearchNewVehicles(string input, decimal? minPrice, decimal? maxPrice, int? minYear, int? maxYear)
        {
            var repo = CarMasterRepoFactory.Create();
            try
            {
                var parameters = new SearchViewModel()
                {
                    Input = input,
                    MinPrice = minPrice,
                    MaxPrice = maxPrice,
                    MinYear = minYear,
                    MaxYear = maxYear
                };

                var result = repo.SearchNewVehicles(parameters);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //For Sales Controller & Admin Controller Search
        [Route("api/search/searchsalesvehicles")]
        [AcceptVerbs("GET")]
        public IHttpActionResult SearchSalesVehicles(string input, decimal? minPrice, decimal? maxPrice, int? minYear, int? maxYear)
        {
            var repo = CarMasterRepoFactory.Create();
            try
            {
                var parameters = new SearchViewModel()
                {
                    Input = input,
                    MinPrice = minPrice,
                    MaxPrice = maxPrice,
                    MinYear = minYear,
                    MaxYear = maxYear
                };

                var result = repo.SearchSalesVehicles(parameters);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/sales/makes/getall")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetMakes()
        {
            var repo = CarMasterRepoFactory.Create();
            try
            {
                var result = repo.GetAllMakes();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/sales/models/getall")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetModels()
        {
            var repo = CarMasterRepoFactory.Create();
            try
            {
                var result = repo.GetAllModels();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/admin/models/{id}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetModelByMake(int id)
        {
            List<Model> models = CarMasterRepoFactory.Create().GetModelByMakeId(id);
            return Ok(models);        
        }
        [Route("api/salesreport")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetSalesReport(int? userId, string fromDate, string toDate)
        {
            var repo = CarMasterRepoFactory.Create();
            try
            {
                DateTime fDate = DateTime.Parse(fromDate);
                DateTime tDate = DateTime.Parse(toDate);

                var parameters = new TotalSalesViewModel()
                {
                    UserId = userId,
                    FromDate = fDate,
                    ToDate = tDate
                };

                var result = repo.SearchPurchases(parameters);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
