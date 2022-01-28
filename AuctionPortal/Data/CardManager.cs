using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AuctionPortal.Data
{
    public static class CardManager
    {
        private static List<Card> _cards;


        public static async Task InitializeCards()
        {
            var cardsString=await FileWriteRead.ReadTextAsync("cards.json");
            var cards = JsonConvert.DeserializeObject<List<Card>>(cardsString);
            _cards = cards;
        }

        public static Card GetCardInfoByNumber(string number)
        {
            return _cards.FirstOrDefault(card => card.CardNumber == number);
        }

        public static async Task ChargeCard(string cardNumber, decimal amount)
        {
            var cardsString=await FileWriteRead.ReadTextAsync("cards.json");
            var cards = JsonConvert.DeserializeObject<List<Card>>(cardsString);
            if (cards != null)
            {
                foreach (var card in cards.Where(card => card.CardNumber == cardNumber))
                {
                    card.CardLimit -= amount;
                    _cards = cards;
                    await FileWriteRead.WriteTextAsync("cards.json", JsonConvert.SerializeObject(cards));
                }
            }
        }
    }
}