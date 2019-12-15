using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DvdLib.Models;

namespace DvdLib.Data
{
    public class DvdRepositoryMock : IDvdRepository
    {
        private static List<Dvd> _dvds;

        static DvdRepositoryMock()
        {
            _dvds = new List<Dvd>()
            {
                new Dvd {DvdId=1, Title="Saving Private Ryan", Director="Steven Spielberg", ReleaseYear=1998, Rating="R", Notes="Top 10er"},
                new Dvd {DvdId=2, Title="Jumanji", Director="Joe Johnston", ReleaseYear=1995, Rating="PG", Notes="RIP Robin"}
            };
        }
        public void CreateDvd(Dvd info)
        {
            if(_dvds.Any())
            {
                info.DvdId = _dvds.Max(x => x.DvdId) + 1;
            }
            else
            {
                info.DvdId = 1;
            }
            _dvds.Add(info);
        }

        public void DeleteDvd(int DvdId)
        {
            _dvds.RemoveAll(x => x.DvdId == DvdId);
        }

        public List<Dvd> GetAllDvds()
        {
            return _dvds;
        }

        public List<Dvd> GetDvdByDirector(string director)
        {
            return _dvds.Where(x => x.Director == director).ToList();
        }

        public Dvd GetDvdByID(int DvdId)
        {
            return _dvds.FirstOrDefault(x => x.DvdId == DvdId);
        }

        public List<Dvd> GetDvdByRating(string rating)
        {
            return _dvds.Where(x => x.Rating == rating).ToList();
        }

        public List<Dvd> GetDvdByReleaseYear(int releaseYear)
        {
            return _dvds.Where(x => x.ReleaseYear == releaseYear).ToList();
        }

        public List<Dvd> GetDvdByTitle(string title)
        {
            return _dvds.Where(x => x.Title == title).ToList();
        }

        public void UpdateDvd(Dvd info)
        {
            _dvds.RemoveAll(x => x.DvdId == info.DvdId);
            _dvds.Add(info);
        }
    }
}
