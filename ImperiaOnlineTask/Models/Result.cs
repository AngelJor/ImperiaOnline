using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImperiaOnlineTask.Models
{
    public class Result
    {
        public Card[] CardList
        {
            get;
            set;
        }
        public int Gold
        {
            get;
            set;
        }
        public int Diamonds
        {
            get;
            set;
        }
        public Card BonusCard
        {
            get;
            set;
        }
    }
}
