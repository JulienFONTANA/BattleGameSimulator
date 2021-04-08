using System.Collections.Generic;
using System.Linq;
using BattleCardSimulator.Interfaces;

namespace BattleCardSimulator
{
    public class DeckService : IDeckService
    {
        public void InitBattleGame(out IList<string> half1, out IList<string> half2)
        {
            var deck = InitDeck();
            deck.Shuffle();
            half1 = deck.Take(26).ToList();
            half2 = deck.Skip(26).Take(26).ToList();
        }

        private static IList<string> InitDeck()
        {
            return new List<string>
            {
                // Clubs
                "AC", "KC", "QC", "JC", "TC", "9C", "8C", "7C", "6C", "5C", "4C", "3C", "2C",
                // Hearts
                "AH", "KH", "QH", "JH", "TH", "9H", "8H", "7H", "6H", "5H", "4H", "3H", "2H",
                // Spades
                "AS", "KS", "QS", "JS", "TS", "9S", "8S", "7S", "6S", "5S", "4S", "3S", "2S",
                // Diamonds
                "AD", "KD", "QD", "JD", "TD", "9D", "8D", "7D", "6D", "5D", "4D", "3D", "2D"
            };
        }
    }
}
