using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImperiaOnlineTask.Models
{
    public class Card
    {
        public Card(int cardId, string rarity)
        {
            CardId = cardId;
            Rarity = rarity;
            Quantity = 0;
        }
        public Card(int cardId, string rarity, int quantity)
        {
            CardId = cardId;
            Rarity = rarity;
            Quantity = quantity;
        }

        public int CardId
        {
            get;
            set;
        }
        public string Rarity
        {
            get;
            set;
        }
        public int Quantity
        {
            get;
            set;
        }
        public static Card GetCardById(int id)
        {


            foreach (Card card in Card.AllCards())
            {
                if(card.CardId == id)
                {
                    return card;
                }
            }

            return null;
        }
        public static List<int> GetCardsByRarity(string rarity)
        {
            
            List<int> chosen = new List<int>();
            foreach (Card card in Card.AllCards())
            {
                if (card.Rarity.Equals(rarity))
                {
                    chosen.Add(card.CardId);
                }
            }
            return chosen;
        }
        public static List<Card> AllCards()
        {
            Card card1 = new Card(1, "common");
            Card card2 = new Card(2, "common");
            Card card3 = new Card(3, "common");
            Card card4 = new Card(4, "common");
            Card card5 = new Card(5, "common");
            Card card6 = new Card(6, "rare");
            Card card7 = new Card(7, "rare");
            Card card8 = new Card(8, "rare");
            Card card9 = new Card(9, "rare");
            Card card10 = new Card(10, "rare");
            Card card11 = new Card(11, "heroic");
            Card card12 = new Card(12, "heroic");

            List<Card> cards = new List<Card> { card1, card2, card3, card4, card5, card6, card7, card8, card9, card10, card11, card12 };

            return cards;
        }
        public static List<int> AllCardsId()
        {
            List<int> Ids = new List<int>();
            List<Card> cards = Card.AllCards();
            for(int i = 0; i < cards.Count; i++)
            {
                Ids.Add(cards[i].CardId);
            }
            return Ids;
        }
    }
}
