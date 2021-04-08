using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleCardSimulator
{
    public static class ExtentionMethods
    {
        private static readonly Random Rand = new Random(DateTime.UtcNow.Millisecond);

        public static void Shuffle(this IList<string> deck)
        {
            var n = deck.Count;
            while (n > 1)
            {
                n--;
                var k = Rand.Next(n + 1);
                var value = deck[k];
                deck[k] = deck[n];
                deck[n] = value;
            }
        }

        public static string DrawCard(this IList<string> deck)
        {
            var card = deck.First();
            deck.Remove(card);
            return card;
        }

        public static bool Empty(this IList<string> deck)
        {
            return !deck.Any();
        }
    }
}
