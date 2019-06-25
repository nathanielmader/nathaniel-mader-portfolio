using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMManager.Models;

namespace SMManager.Data
{
    public class SMRepository
    {
        private List<Snake> _snakeList = new List<Snake>();
        //{
        //    new Snake
        //    {
        //        ID=1,
        //        Family=SnakeFamily.Viperidae,
        //        CommonSpeciesName="Bob",
        //        LengthInCentimeters=23M,
        //        Venomous=true
        //    },

        //    new Snake
        //    {
        //        ID=2,
        //        Family=SnakeFamily.Colubridae,
        //        CommonSpeciesName="Steve",
        //        LengthInCentimeters=26M,
        //        Venomous=true
        //    }
        //};


        public Snake Create(Snake snake)
        {
            _snakeList.Add(snake);
            return snake;
        }

        public List<Snake> ReadAll()
        {

            return _snakeList;
        }

        public Snake ReadByID(int id)
        {

            foreach (var s in _snakeList)
            {
                if (s.ID == id)
                {
                    return s;
                }
            }
            return null;
        }

        public void Update(int ID, Snake snake)
        {
            Snake snakeToUpdate = _snakeList.FirstOrDefault(s => s.ID == ID);
            int x = _snakeList.IndexOf(snakeToUpdate);
            _snakeList[x] = snake;

        }

        public void Delete(int ID)
        {
            Snake snakeToDelete = _snakeList.Find(s => s.ID == ID);
            _snakeList.Remove(snakeToDelete);
        }
    }
}
