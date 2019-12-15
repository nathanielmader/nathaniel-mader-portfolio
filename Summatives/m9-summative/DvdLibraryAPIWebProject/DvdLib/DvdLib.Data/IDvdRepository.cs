using DvdLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLib.Data
{
    public interface IDvdRepository
    {
        Dvd GetDvdByID(int DvdId);
        List<Dvd> GetAllDvds();
        List<Dvd> GetDvdByTitle(string title);
        List<Dvd> GetDvdByReleaseYear(int releaseYear);
        List<Dvd> GetDvdByDirector(string director);
        List<Dvd> GetDvdByRating(string rating);
        void CreateDvd(Dvd info);
        void UpdateDvd(Dvd info);
        void DeleteDvd(int DvdId);
    }
}
