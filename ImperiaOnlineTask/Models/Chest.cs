using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace ImperiaOnlineTask.Models
{
    public class Chest
    {

        public int ChestId
        {
            get;
            set;
        }
        public int CountOfCadrs
        {
            get;
            set;
        }
        public List<string> QualityOfCard
        {
            get;
            set;
        }
        public int QuantityOfCadrs
        {
            get;
            set;
        }
        public int Diamonds
        {
            get;
            set;
        }
        public List<int> CardId
        {
            get;
            set;
        }
        public int Gold
        {
            get;
            set;
        }
        public int BonusChance
        {
            get;
            set;
        }
        public int NewCardBonus
        {
            get;
            set;
        }

        private static int[] RandomNumbers(int NumberCount, int Sum)
        {
            int[] numbers = new int[NumberCount];
            for (int i = 0; i < Sum; i++)
            {
                Random rnd = new Random();

                numbers[rnd.Next(0, Sum) % NumberCount]++;
            }
            return numbers;
        }
        public static string MakeChest(Chest chest)
        {
            int[] CardsBySlot = Chest.RandomNumbers(chest.CountOfCadrs, chest.QuantityOfCadrs);
            Random r = new Random();
            int BonusId;
            Person person = new Person(1);
            Card[] cards = new Card[chest.CountOfCadrs];
            List<int> AllCardsId = Card.AllCardsId();
            List<int> LeftCardsId = Card.AllCardsId();
            List<int> SelectedId = chest.CardId;
            List<int> rareCardsId = Card.GetCardsByRarity("rare");
            List<int> commonCardsId = Card.GetCardsByRarity("common");
            List<int> heroicCardsId = Card.GetCardsByRarity("heroic");
            List<int> PlayerCardsId = person.Cards;
            List<int> ChosenCardsId = new List<int>();
            switch (chest.ChestId)
            {
                case 1:
                    for (int k = 0; k < PlayerCardsId.Count; k++)
                    {
                        for (int j = 0; j < AllCardsId.Count; j++)
                        {
                            if (PlayerCardsId[k] == AllCardsId[j])
                            {
                                LeftCardsId.Remove(PlayerCardsId[k]);
                                break;
                            }
                        }

                    }
                    if (r.Next(1, 100) <= chest.NewCardBonus) 
                    {                    
                        if (LeftCardsId.Count > 1)
                        {
                            Card card1 = Card.GetCardById(LeftCardsId[r.Next(0, LeftCardsId.Count)]);
                            card1.Quantity = CardsBySlot[0];
                            cards[0] = card1;
                        }
                        else
                        {
                            Card card1 = Card.GetCardById(LeftCardsId[0]);
                            card1.Quantity = CardsBySlot[0];
                            cards[0] = card1;
                        }
                        for (int i = 0; i < chest.CountOfCadrs - 1; i++)
                        {
                            ChosenCardsId.Add(PlayerCardsId[r.Next(PlayerCardsId.Count)]);
                            PlayerCardsId.Remove(ChosenCardsId[i]);
                            Card card = Card.GetCardById(ChosenCardsId[i]);
                            card.Quantity = CardsBySlot[i+1];
                            cards[i+1] = card;
                        }
                        if (r.Next(1, 100) <= chest.BonusChance)
                        {
                            BonusId = r.Next(heroicCardsId.Count);
                            Card BonusCard = Card.GetCardById(heroicCardsId[BonusId]);
                            BonusCard.Quantity = 5;
                            string json1 = JsonConvert.SerializeObject(new
                            {
                                Success = true,
                                RewardList = new List<Result>()
                        {
                            new Result {
                                CardList = cards,
                                Diamonds = chest.Diamonds,
                                Gold = chest.Gold * person.Tier,
                                BonusCard = BonusCard
                                }
                            }
                            });
                            return json1;
                        }
                        else

                        {
                            string json1 = JsonConvert.SerializeObject(new
                            {
                                Success = true,
                                RewardList = new List<Result>()
                        {
                            new Result {
                                CardList = cards,
                                Diamonds = chest.Diamonds,
                                Gold = chest.Gold * person.Tier
                            }
                        }
                            });
                            return json1;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < chest.CountOfCadrs; i++)
                        {
                            ChosenCardsId.Add(PlayerCardsId[r.Next(PlayerCardsId.Count)]);
                            PlayerCardsId.Remove(ChosenCardsId[i]);
                            Card card = Card.GetCardById(ChosenCardsId[i]);
                            card.Quantity = CardsBySlot[i];
                            cards[i] = card;
                        }

                        if (r.Next(1, 100) <= chest.BonusChance)
                        {
                            BonusId = r.Next(heroicCardsId.Count);
                            Card BonusCard = Card.GetCardById(heroicCardsId[BonusId]);
                            BonusCard.Quantity = 5;
                            string json1 = JsonConvert.SerializeObject(new
                            {
                                Success = true,
                                RewardList = new List<Result>()
                        {
                            new Result {
                                CardList = cards,
                                Diamonds = chest.Diamonds,
                                Gold = chest.Gold * person.Tier,
                                BonusCard = BonusCard
                                }
                            }
                            });
                            return json1;
                        }
                        else

                        {
                            string json1 = JsonConvert.SerializeObject(new
                            {
                                Success = true,
                                RewardList = new List<Result>()
                        {
                            new Result {
                                CardList = cards,
                                Diamonds = chest.Diamonds,
                                Gold = chest.Gold * person.Tier
                            }
                        }
                            });
                            return json1;
                        }
                    }
                case 2:
                    for (int k = 0; k < PlayerCardsId.Count; k++)
                    {
                        for (int j = 0; j < AllCardsId.Count; j++)
                        {
                            if (PlayerCardsId[k] == AllCardsId[j])
                            {
                                LeftCardsId.Remove(PlayerCardsId[k]);
                                break;
                            }
                        }

                    }
                    List<int> LeftRareCardsId = new List<int>();
                    for (int i = 0; i < LeftCardsId.Count; i++)
                    {
                        if (Card.GetCardById(LeftCardsId[i]).Rarity == chest.QualityOfCard[0])
                        {
                            LeftRareCardsId.Add(LeftCardsId[i]);
                        }
                    }
                    List<int> PlayerRareCardsId = new List<int>();

                    for (int i = 0; i < PlayerCardsId.Count; i++)
                    {
                        if (Card.GetCardById(PlayerCardsId[i]).Rarity == chest.QualityOfCard[0])
                        {
                            PlayerRareCardsId.Add(PlayerCardsId[i]);
                        }
                    }
                    if (r.Next(1, 100) <= chest.NewCardBonus && LeftRareCardsId.Count > 0)
                    {
                        if (LeftRareCardsId.Count > 1) 
                        {
                            Card card1 = Card.GetCardById(LeftRareCardsId[r.Next(0, LeftRareCardsId.Count)]);
                            card1.Quantity = CardsBySlot[0];
                            cards[0] = card1;
                        }
                        else
                        {
                            Card card1 = Card.GetCardById(LeftRareCardsId[0]);
                            card1.Quantity = CardsBySlot[0];
                            cards[0] = card1;
                        }
                       
                        for (int i = 0; i < chest.CountOfCadrs - 1; i++)
                        {

                            ChosenCardsId.Add(PlayerRareCardsId[r.Next(PlayerRareCardsId.Count)]);

                            PlayerRareCardsId.Remove(ChosenCardsId[i]);

                            Card card = Card.GetCardById(ChosenCardsId[i]);
                            card.Quantity = CardsBySlot[i + 1];
                            cards[i + 1] = card;
                        }

                        string json2 = JsonConvert.SerializeObject(new
                        {
                            Success = true,
                            RewardList = new List<Result>()
                        {
                            new Result {
                                CardList = cards,
                                Gold = 1000
                            }
                        }
                        });
                        return json2;
                    }
                    else
                    {
                        for (int i = 0; i < chest.CountOfCadrs; i++)
                        {

                            ChosenCardsId.Add(PlayerRareCardsId[r.Next(PlayerRareCardsId.Count)]);

                            PlayerRareCardsId.Remove(ChosenCardsId[i]);

                            Card card = Card.GetCardById(ChosenCardsId[i]);
                            card.Quantity = CardsBySlot[i];
                            cards[i] = card;
                        }

                        string json2 = JsonConvert.SerializeObject(new
                        {
                            Success = true,
                            RewardList = new List<Result>()
                        {
                            new Result {
                                CardList = cards,
                                Gold = 1000
                            }
                        }
                        });
                        return json2;
                    }
                case 3:

                    List<int> PlayerNewSelectedCardsId = SelectedId;
                    List<int> PlayerSelectedCardsId = new List<int>();
                    for (int k = 0; k < PlayerCardsId.Count; k++)
                    {
                        for (int j = 0; j < SelectedId.Count; j++)
                        {
                            if (PlayerCardsId[k] == SelectedId[j])
                            {
                                PlayerNewSelectedCardsId.Remove(PlayerCardsId[k]);
                                PlayerSelectedCardsId.Add(PlayerCardsId[k]);
                            }
                        }
                    }

                    if (r.Next(1, 100) <= chest.NewCardBonus && PlayerNewSelectedCardsId.Count > 0)
                    {
                        if (PlayerNewSelectedCardsId.Count > 1)
                        {
                            Card card1 = Card.GetCardById(PlayerNewSelectedCardsId[r.Next(0, PlayerNewSelectedCardsId.Count)]);
                            card1.Quantity = CardsBySlot[0];
                            cards[0] = card1;
                        }
                        else
                        {
                            Card card1 = Card.GetCardById(PlayerNewSelectedCardsId[0]);
                            card1.Quantity = CardsBySlot[0];
                            cards[0] = card1;
                        }

                        for (int i = 0; i < chest.CountOfCadrs - 1; i++)
                        {

                            ChosenCardsId.Add(PlayerSelectedCardsId[r.Next(PlayerSelectedCardsId.Count)]);
                            PlayerSelectedCardsId.Remove(ChosenCardsId[i]);
                            Card card = Card.GetCardById(ChosenCardsId[i]);
                            card.Quantity = CardsBySlot[i + 1];
                            cards[i + 1] = card;
                        }

                        string json3 = JsonConvert.SerializeObject(new
                        {
                            Success = true,
                            RewardList = new List<Result>()
                        {
                            new Result {
                                CardList = cards
                            }
                        }
                        });
                        return json3;
                    }
                    else
                    {
                        for (int i = 0; i < chest.CountOfCadrs; i++)
                        {

                            ChosenCardsId.Add(PlayerSelectedCardsId[r.Next(PlayerSelectedCardsId.Count)]);
                            PlayerSelectedCardsId.Remove(ChosenCardsId[i]);
                            Card card = Card.GetCardById(ChosenCardsId[i]);
                            card.Quantity = CardsBySlot[i];
                            cards[i] = card;
                        }

                        string json3 = JsonConvert.SerializeObject(new
                        {
                            Success = true,
                            RewardList = new List<Result>()
                        {
                            new Result {
                                CardList = cards
                            }
                        }
                        });
                        return json3;
                    }
                default:
                    string json4 = JsonConvert.SerializeObject(new
                    {
                        Success = false
                    });
                    return json4;
            }
        }

    }
}
