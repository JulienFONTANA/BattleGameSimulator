using System.Collections.Generic;
using System.Linq;
using BattleCardSimulator.Interfaces;

namespace BattleCardSimulator
{
    public class CardComparer : ICardComparer
    {
        public CompareState CompareCards(string cardP1, string cardP2)
        {
            var valueCardP1 = GetCardValue(cardP1);
            var valueCardP2 = GetCardValue(cardP2);

            if (valueCardP1 == valueCardP2)
            {
                return CompareState.Battle;
            }
            return valueCardP1 > valueCardP2 
                ? CompareState.Player1Won 
                : CompareState.Player2Won;
        }

        private static int GetCardValue(string card)
        {
            return CardRanks.FirstOrDefault(c => c.Key == card[0]).Value;
        }

        private static readonly IDictionary<char, int> CardRanks = new Dictionary<char, int>
        {
            {'2', 1},
            {'3', 2},
            {'4', 3},
            {'5', 4},
            {'6', 5},
            {'7', 6},
            {'8', 7},
            {'9', 8},
            {'T', 9},
            {'J', 10},
            {'Q', 11},
            {'K', 12},
            {'A', 13}
        };
    }
}