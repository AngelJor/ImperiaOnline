using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImperiaOnlineTask.Models
{
    public class Person
    {
        private List<int> CardsArray = new List<int> { 1, 2, 3, 4, 6, 8, 9};
        public Person(int personId)
        {
            PersonId = personId;
            Cards = CardsArray;
            Tier = 5;
        }

        public int PersonId
        {
            get;
            set;
        }
        public List<int> Cards
        {
            get;
            set;
        }
        public int Tier
        {
            get;
            set;
        }
    }
}
