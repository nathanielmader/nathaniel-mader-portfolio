using DvdLib.Data;
using DvdLib.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DvdLib.UI.Controllers
{
    //Three parameter values, * means "All"
    //Controller will now accept CORS requests from any origins with any headers for any methods
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DvdController : ApiController
    {
        //Works
        [Route("dvd/{DvdId}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDvdById(int DvdId)
        {
            Dvd dvd = DvdRepositoryFactory.Create().GetDvdByID(DvdId);

            if(dvd == null)
            {
                return NotFound();
            }
            else
            {
                //Creates HTTP Response status 200
                return Ok(dvd);
            }
        }
        //Works
        [Route("dvds")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAllDvds()
        {
            List<Dvd> dvds = DvdRepositoryFactory.Create().GetAllDvds();

            if (dvds == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(dvds);
            }
        }
        //Works
        [Route("dvds/title/{title}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDvdByTitle(string title)
        {
            List<Dvd> dvds = DvdRepositoryFactory.Create().GetDvdByTitle(title);

            if (dvds == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(dvds);
            }
        }
        //Works
        [Route("dvds/year/{releaseYear}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDvdByReleaseYear(int releaseYear)
        {
            List<Dvd> dvds = DvdRepositoryFactory.Create().GetDvdByReleaseYear(releaseYear);

            if (dvds == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(dvds);
            }
        }
        //Works
        [Route("dvds/director/{directorName}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDvdByDirector(string director)
        {
            List<Dvd> dvds = DvdRepositoryFactory.Create().GetDvdByDirector(director);

            if (dvds == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(dvds);
            }
        }
        //Works
        [Route("dvds/rating/{rating}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDvdByRating(string rating)
        {
            List<Dvd> dvds = DvdRepositoryFactory.Create().GetDvdByRating(rating);

            if (dvds == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(dvds);
            }
        }
        //Works
        [Route("dvd")]
        [AcceptVerbs("POST")]
        public IHttpActionResult CreateDvd(Dvd info)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Dvd newDvd = new Dvd()
            {
                Title = info.Title,
                ReleaseYear = info.ReleaseYear,
                Director = info.Director,
                Rating = info.Rating,
                Notes = info.Notes
            };

            DvdRepositoryFactory.Create().CreateDvd(info);
            return Created($"dvd/{info.DvdId}", info);
        }
        //Work
        [Route("dvd/{DvdId}")]
        [AcceptVerbs("PUT")]
        public IHttpActionResult UpdateDvd(Dvd info)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Dvd dvd = DvdRepositoryFactory.Create().GetDvdByID(info.DvdId);

            if (dvd == null)
            {
                return NotFound();
            }

            dvd.DvdId = info.DvdId;
            dvd.Title = info.Title;
            dvd.ReleaseYear = info.ReleaseYear;
            dvd.Director = info.Director;
            dvd.Rating = info.Rating;
            dvd.Notes = info.Notes;

            DvdRepositoryFactory.Create().UpdateDvd(dvd);
            return Ok(dvd);
        }
        //Works
        [Route("dvd/{DvdId}")]
        [AcceptVerbs("DELETE")]
        public IHttpActionResult DeleteDvd(int DvdId)
        {
            Dvd dvd = DvdRepositoryFactory.Create().GetDvdByID(DvdId);

            if (dvd == null)
            {
                return NotFound();
            }

            DvdRepositoryFactory.Create().DeleteDvd(DvdId);
            return Ok();
        }
    }
}
