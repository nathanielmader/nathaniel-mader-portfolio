using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DvdLib.Models;

namespace DvdLib.Data
{
    public class DvdRepositoryEF : IDvdRepository
    {
        DvdLibEntities context = new DvdLibEntities();

        public void CreateDvd(Dvd info)
        {
            context.Dvds.Add(info);
            context.SaveChanges();
        }

        public void DeleteDvd(int DvdId)
        {
            Dvd dvd = context.Dvds.Find(DvdId);
            context.Dvds.Remove(dvd);
            context.SaveChanges();
        }

        public List<Dvd> GetAllDvds()
        {
            using(var context = new DvdLibEntities())
            {
                var dvds = from d in context.Dvds
                           select d;

                return dvds.ToList();
            }
        }

        public List<Dvd> GetDvdByDirector(string director)
        {
            var result = (from d in context.Dvds where d.Director == director select d).ToList();
            return result;
        }

        public Dvd GetDvdByID(int DvdId)
        {
            var result = (from d in context.Dvds where d.DvdId == DvdId select d).FirstOrDefault();
            return result;
        }

        public List<Dvd> GetDvdByRating(string rating)
        {
            var result = (from d in context.Dvds where d.Rating == rating select d).ToList();
            return result;
        }

        public List<Dvd> GetDvdByReleaseYear(int releaseYear)
        {
            var result = (from d in context.Dvds where d.ReleaseYear == releaseYear select d).ToList();
            return result;
        }

        public List<Dvd> GetDvdByTitle(string title)
        {
            var result = (from d in context.Dvds where d.Title == title select d).ToList();
            return result;
        }

        public void UpdateDvd(Dvd info)
        {
            context.Entry(info).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
