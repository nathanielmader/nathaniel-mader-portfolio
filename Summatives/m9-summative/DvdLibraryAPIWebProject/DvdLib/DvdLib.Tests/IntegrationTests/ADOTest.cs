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
    public class AdoTests
    {
        //Reset data between each test run
        //Why did this not get handled in database?
        [SetUp]
        public void Init()
        {
            //NOTE: Add reference to system.config in Test Project
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "DbReset";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Connection = cn;

                //Open connection
                cn.Open();

                //Execute reset query
                cmd.ExecuteNonQuery();
            }
        }
        [Test]
        public void CanLoadDvd()
        {
            var repo = new DvdRepositoryADO();

            var dvds = repo.GetAllDvds();

            Assert.AreEqual(2, dvds.Count);
            Assert.AreEqual("The Lion King", dvds[0].Title);
            Assert.AreEqual(2010, dvds[1].ReleaseYear);
            Assert.AreEqual("Ehhhhh", dvds[1].Notes);
            Assert.AreNotEqual("Some Guy", dvds[1].Director);
        }

        [Test]
        public void CanGetDvdById()
        {
            var repo = new DvdRepositoryADO();

            var dvd = repo.GetDvdByID(1);

            Assert.AreEqual(1, dvd.DvdId);
            Assert.AreEqual("The Lion King", dvd.Title);
            Assert.AreEqual(1992, dvd.ReleaseYear);
            Assert.AreNotEqual("Ehhhhh", dvd.Notes);
            Assert.AreEqual("Some Guy", dvd.Director);
        }

        [Test]
        public void NotFoundDvdReturnNull()
        {
            var repo = new DvdRepositoryADO();
            var dvd = repo.GetDvdByID(1000);

            Assert.IsNull(dvd);
        }

        [Test]
        public void CanCreateDvd()
        {
            Dvd dvd = new Dvd();

            var repo = new DvdRepositoryADO();

            dvd.DvdId = 3;
            dvd.Title = "Training Day";
            dvd.ReleaseYear = 2011;
            dvd.Director = "Joe Blow";
            dvd.Rating = "R";
            dvd.Notes = null;

            repo.CreateDvd(dvd);

            Assert.AreEqual(3, dvd.DvdId);
            Assert.AreEqual("Training Day", dvd.Title);
            Assert.AreEqual(2011, dvd.ReleaseYear);
            Assert.AreEqual("Joe Blow", dvd.Director);
            Assert.AreNotEqual("Ehhhhh", dvd.Notes);

            //NOTE ISSUE: Need to reset database to initial state.
        }

        [Test]
        public void CanUpdateDvd()
        {
            Dvd dvd = new Dvd();
            var repo = new DvdRepositoryADO();

            dvd.DvdId = 3;
            dvd.Title = "Training Day";
            dvd.ReleaseYear = 2011;
            dvd.Director = "Joe Blow";
            dvd.Rating = "R";
            dvd.Notes = null;

            repo.CreateDvd(dvd);

            //dvd.DvdId = 3;
            dvd.Title = "Day";
            dvd.ReleaseYear = 2019;
            dvd.Director = "That One Guy";
            dvd.Rating = "R";
            dvd.Notes = "Hello";

            repo.UpdateDvd(dvd);
            var updatedDvd = repo.GetDvdByID(3);

            Assert.AreEqual(3, updatedDvd.DvdId);
            Assert.AreEqual("Day", updatedDvd.Title);
            Assert.AreEqual(2019, updatedDvd.ReleaseYear);
            Assert.AreNotEqual("Joe Blow", updatedDvd.Director);
            Assert.AreEqual("Hello", updatedDvd.Notes);
        }
        [Test]
        public void CanDeleteDvd()
        {
            Dvd dvd = new Dvd();

            var repo = new DvdRepositoryADO();

            dvd.DvdId = 3;
            dvd.Title = "Training Day";
            dvd.ReleaseYear = 2011;
            dvd.Director = "Joe Blow";
            dvd.Rating = "R";
            dvd.Notes = null;

            repo.CreateDvd(dvd);

            var dvdToDelete = repo.GetDvdByID(3);
            Assert.IsNotNull(dvdToDelete);

            repo.DeleteDvd(3);
            dvdToDelete = repo.GetDvdByID(3);

            Assert.IsNull(dvdToDelete);
        }

        [Test]
        public void CanGetDvdsByDirector()
        {
            var repo = new DvdRepositoryADO();
            var dvds = repo.GetDvdByDirector("Some Guy");

            Assert.IsNotNull(dvds);
            Assert.AreEqual(1, dvds.Count());
            Assert.AreEqual("The Lion King", dvds[0].Title);
            Assert.AreEqual(1992, dvds[0].ReleaseYear);
            Assert.AreEqual("Some Guy", dvds[0].Director);
            Assert.AreEqual("PG", dvds[0].Rating);
            Assert.AreEqual("The best ever!", dvds[0].Notes);

            Dvd addToTest = new Dvd();
            addToTest.DvdId = 3;
            addToTest.Title = "BobbyBuilderBanks";
            addToTest.ReleaseYear = 2000;
            addToTest.Director = "Some Guy";
            addToTest.Rating = "X";
            addToTest.Notes = null;
            repo.CreateDvd(addToTest);

            dvds = repo.GetDvdByDirector("Some Guy");
            Assert.AreEqual(2, dvds.Count());
        }
        [Test]
        public void CanGetDvdsByRating()
        {
            var repo = new DvdRepositoryADO();
            var dvds = repo.GetDvdByRating("PG");

            Assert.IsNotNull(dvds);
            Assert.AreEqual(2, dvds.Count());
            Assert.AreEqual("The Lion King", dvds[0].Title);
            Assert.AreNotEqual("The Lion King", dvds[1].Title);
            Assert.AreEqual(1992, dvds[0].ReleaseYear);
            Assert.AreEqual("PG", dvds[0].Rating);
            Assert.AreEqual("PG", dvds[1].Rating);
        }
        [Test]
        public void CanGetDvdsByTitle()
        {
            var repo = new DvdRepositoryADO();
            var dvds = repo.GetDvdByTitle("The Lion King");

            Assert.IsNotNull(dvds);
            Assert.AreEqual(1, dvds.Count());
            Assert.AreEqual("The Lion King", dvds[0].Title);
            Assert.AreEqual(1992, dvds[0].ReleaseYear);
            Assert.AreEqual("PG", dvds[0].Rating);
        }
        [Test]
        public void CanGetDvdsByReleaseYear()
        {
            var repo = new DvdRepositoryADO();
            var dvds = repo.GetDvdByReleaseYear(2010);

            Assert.IsNotNull(dvds);
            Assert.AreEqual(1, dvds.Count());
            Assert.AreEqual("Up", dvds[0].Title);
            Assert.AreEqual(2010, dvds[0].ReleaseYear);
            Assert.AreEqual("PG", dvds[0].Rating);

            Dvd dvd = new Dvd();
            dvd.DvdId = 3;
            dvd.Title = "Training Day";
            dvd.ReleaseYear = 2010;
            dvd.Director = "Joe Blow";
            dvd.Rating = "R";
            dvd.Notes = null;

            repo.CreateDvd(dvd);

            var x = repo.GetDvdByReleaseYear(2010);
            Assert.AreEqual(2, x.Count());
        }
    }
}
