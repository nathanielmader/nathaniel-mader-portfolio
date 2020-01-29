﻿using CarMast.Data;
using CarMast.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarMast.UI.Controllers
{
    public class ModelsController : ApiController
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

        ////For Admin Controller Search
        //[Route("api/search/searchforpurchasevehicles")]
        //[AcceptVerbs("GET")]
        //public IHttpActionResult SearchForPurchaseVehicles(string input, decimal? minPrice, decimal? maxPrice, int? minYear, int? maxYear)
        //{
        //    var repo = CarMasterRepoFactory.Create();
        //    try
        //    {
        //        var parameters = new SearchViewModel()
        //        {
        //            Input = input,
        //            MinPrice = minPrice,
        //            MaxPrice = maxPrice,
        //            MinYear = minYear,
        //            MaxYear = maxYear
        //        };

        //        var result = repo.SearchSalesVehicles(parameters);
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

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
            catch(Exception ex)
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
    }
}
