using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SMManager.Data;
using SMManager.Models;

namespace SMTests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void CanAddSnakeTest()
        {
            SMRepository repo = new SMRepository();

            Snake newSnake = new Snake();
            newSnake.ID = 1;
            newSnake.Family = SnakeFamily.Boidae;
            newSnake.CommonSpeciesName = "Dr. Phil";
            newSnake.LengthInCentimeters = 35M;
            newSnake.Venomous = false;

            repo.Create(newSnake);

            List<Snake> snakes = repo.ReadAll();
            Assert.AreEqual(1, snakes.Count());

        }


        [Test]
        public void CanReadByIDTest()
        {
            SMRepository repo = new SMRepository();

            Snake newSnake = new Snake();
            newSnake.ID = 2;
            newSnake.Family = SnakeFamily.Boidae;
            newSnake.CommonSpeciesName = "Gandhi";
            newSnake.LengthInCentimeters = 190M;
            newSnake.Venomous = false;

            repo.Create(newSnake);

            List<Snake> snakes = repo.ReadAll();
            Snake snakeToRead = repo.ReadByID(2);

            Assert.AreEqual(2, snakeToRead.ID);
            Assert.AreEqual(SnakeFamily.Boidae, snakeToRead.Family);
            Assert.AreEqual("Gandhi", snakeToRead.CommonSpeciesName);
            Assert.AreEqual(190, snakeToRead.LengthInCentimeters);
            Assert.AreEqual(false, snakeToRead.Venomous);
        }


        [Test]
        public void CanDeleteSnakeTest()
        {
            SMRepository repo = new SMRepository();

            Snake newSnake = new Snake();

            newSnake.ID = 3;
            newSnake.Family = SnakeFamily.Viperidae;
            newSnake.CommonSpeciesName = "James";
            newSnake.LengthInCentimeters = 35M;
            newSnake.Venomous = true;

            Snake third = repo.Create(newSnake);

            List<Snake> snakes = repo.ReadAll();
            Assert.AreEqual(1, snakes.Count());
            repo.Delete(3);
            Assert.AreEqual(0, snakes.Count());
        }

        //[Test]
        //public void CanUpdateSnakeTest()
        //{
        //    SMRepository repo = new SMRepository();

        //    Snake newSnake = new Snake();
        //    newSnake.ID = 3;
        //    newSnake.Family = SnakeFamily.Boidae;
        //    newSnake.CommonSpeciesName = "James";
        //    newSnake.LengthInCentimeters = 35M;
        //    newSnake.Venomous = false;

        //    repo.Create(newSnake);

        //    List<Snake> snakes = repo.ReadAll();
        //    Assert.AreEqual(3, snakes.Count());
        //    repo.Delete(newSnake.ID);
        //    Assert.AreEqual(2, snakes.Count());
        //}
    }
}
