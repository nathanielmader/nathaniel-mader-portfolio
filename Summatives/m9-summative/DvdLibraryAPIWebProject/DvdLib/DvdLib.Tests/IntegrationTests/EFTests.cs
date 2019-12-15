using DvdLib.Data;
using DvdLib.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLib.Tests.IntegrationTests
{
    [TestFixture]
    public class EFTests
    {
        [SetUp]
        public void Init()
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "DbReset";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Connection = cn;
                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        [Test]
        public void CanGetDvds()
        {
            var repo = new DvdRepositoryEF();

            var dvds = repo.GetAllDvds();

            Assert.AreEqual(2, dvds.Count);

            Assert.AreEqual(1, dvds[0].DvdId);
            Assert.AreEqual("Saving Private Ryan", dvds[0].Title);
            Assert.AreEqual(1999, dvds[0].ReleaseYear);
            Assert.AreEqual("Spielberg", dvds[0].Director);
            Assert.AreEqual("R", dvds[0].Rating);
            Assert.AreEqual("Emotional", dvds[0].Notes);
        }

        [Test]
        public void CanGetDvdById()
        {
            var repo = new DvdRepositoryEF();

            var dvd = repo.GetDvdByID(1);

            Assert.IsNotNull(dvd);;

            Assert.AreEqual(1, dvd.DvdId);
            Assert.AreEqual("Saving Private Ryan", dvd.Title);
            Assert.AreEqual(1999, dvd.ReleaseYear);
            Assert.AreNotEqual("Ehhhhh", dvd.Notes);
            Assert.AreEqual("Spielberg", dvd.Director);
        }

        [Test]
        public void NotFoundDvdReturnsNull()
        {
            var repo = new DvdRepositoryEF();

            var dvdId = 1000;

            var dvd = repo.GetDvdByID(dvdId);

            Assert.IsNull(dvd);
        }

        [Test]
        public void CanGetDvdsByRating()
        {
            var repo = new DvdRepositoryEF();

            var dvds = repo.GetDvdByRating("PG");

            Assert.AreEqual(1, dvds.Count);
            Assert.AreEqual("Elf", dvds[0].Title);
            Assert.AreEqual(2003, dvds[0].ReleaseYear);
            Assert.AreEqual("Berenbaum", dvds[0].Director);
            Assert.AreEqual("PG", dvds[0].Rating);
            Assert.AreEqual("Best", dvds[0].Notes);
        }

        [Test]
        public void CanGetDvdsByDirector()
        {
            var repo = new DvdRepositoryEF();
            var dvds = repo.GetDvdByDirector("Spielberg");

            Assert.AreEqual(1, dvds.Count);
            Assert.AreEqual("Saving Private Ryan", dvds[0].Title);
            Assert.AreEqual(1999, dvds[0].ReleaseYear);
            Assert.AreEqual("R", dvds[0].Rating);
            Assert.AreEqual("Emotional", dvds[0].Notes);

            Dvd dvdToCreate = new Dvd();

        }

        [Test]
        public void CanGetDvdsByTitle()
        {
            var repo = new DvdRepositoryEF();
            var dvds = repo.GetDvdByTitle("The Lion King");

            Assert.AreEqual(1, dvds.Count);

            Assert.AreEqual(1, dvds[0].DvdId);
            Assert.AreEqual("The Lion King", dvds[0].Title);
            Assert.AreEqual(1992, dvds[0].ReleaseYear);
            Assert.AreEqual("Some Guy", dvds[0].Director);
            Assert.AreEqual("PG", dvds[0].Rating);
            Assert.AreEqual("The best ever!", dvds[0].Notes);
        }

        [Test]
        public void CanGetDvdsByReleaseYear()
        {
            var repo = new DvdRepositoryEF();

            var dvds = repo.GetDvdByReleaseYear(2003);

            Assert.AreEqual(1, dvds.Count);

            Assert.AreEqual(1, dvds[1].DvdId);
            Assert.AreEqual("Elf", dvds[1].Title);
            Assert.AreEqual(2003, dvds[1].ReleaseYear);
            Assert.AreEqual("Berenbaum", dvds[1].Director);
            Assert.AreEqual("PG", dvds[1].Rating);
            Assert.AreEqual("Best", dvds[1].Notes);

        }

        [Test]
        public void CanCreateDvd()
        {
            Dvd dvdToCreate = new Dvd();
            var repo = new DvdRepositoryEF();

            dvdToCreate.DvdId = 3;
            dvdToCreate.Title = "John";
            dvdToCreate.ReleaseYear = 2000;
            dvdToCreate.Director = "Smith";
            dvdToCreate.Rating = "R";
            dvdToCreate.Notes = null;

            repo.CreateDvd(dvdToCreate);

            Assert.AreEqual(3, dvdToCreate.DvdId);
            Assert.AreEqual("John", dvdToCreate.Title);
            Assert.AreEqual(2000, dvdToCreate.ReleaseYear);
            Assert.AreEqual("Smith", dvdToCreate.Director);
            Assert.AreEqual("R", dvdToCreate.Rating);
            Assert.IsNull(dvdToCreate.Notes);
        }

        [Test]
        public void CanUpdateDvd()
        {
            Dvd dvdToCreate = new Dvd();
            var repo = new DvdRepositoryEF();

            dvdToCreate.DvdId = 4;
            dvdToCreate.Title = "BOB";
            dvdToCreate.ReleaseYear = 2054;
            dvdToCreate.Director = "Smith";
            dvdToCreate.Rating = "R";
            dvdToCreate.Notes = "Coolio";

            repo.CreateDvd(dvdToCreate);

            repo.UpdateDvd(dvdToCreate);

            var dvdId = 3;
            var updatedDvd = repo.GetDvdByID(dvdId);

            Assert.AreEqual("A Truly Awesome Tale", updatedDvd.Title);
            Assert.AreEqual(2018, updatedDvd.ReleaseYear);
            Assert.AreEqual("Johnny Cash", updatedDvd.Director);
            Assert.AreEqual("NR", updatedDvd.Rating);
            Assert.AreEqual("This is a truly awesome tale!", updatedDvd.Notes);
        }

        [Test]
        public void CanDeleteDvd()
        {
            Dvd dvdToCreate = new Dvd();
            var repo = new DvdRepositoryEF();

            dvdToCreate.DvdId = 3;
            dvdToCreate.Title = "Elfssdsdsdsdsd";
            dvdToCreate.ReleaseYear = 2010;
            dvdToCreate.Director = "Berenbaum";
            dvdToCreate.Rating = "PG";
            dvdToCreate.Notes = "Best";

            repo.CreateDvd(dvdToCreate);

            var dvdId = 3;
            var loaded = repo.GetDvdByID(dvdId);
            Assert.IsNotNull(loaded);

            repo.DeleteDvd(dvdId);
            loaded = repo.GetDvdByID(dvdId);
            Assert.IsNull(loaded);
        }
    }
}
