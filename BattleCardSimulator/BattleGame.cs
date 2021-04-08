using BattleCardSimulator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleCardSimulator
{
    public class BattleGame : IBattleGame
    {
        private readonly IDeckService _deckService;
        private readonly ICardComparer _cardComparer;

        public BattleGame(IDeckService deckService,
            ICardComparer cardComparer)
        {
            _deckService = deckService;
            _cardComparer = cardComparer;
        }

        public GameResult Play()
        {
            Console.WriteLine();
            var pileP1 = new List<string>();
            var pileP2 = new List<string>();
            var cardP1 = string.Empty;
            var cardP2 = string.Empty;
            _deckService.InitBattleGame(out var deckP1, out var deckP2);

            var gameOver = false;
            var turnsTaken = 0;
            while (!gameOver)
            {
                Console.Write($"[{++turnsTaken:D4}]");
                var handOver = false;
                IList<string> battleCards = new List<string>();
                while (!handOver)
                {
                    if (deckP1.Any())
                        cardP1 = deckP1.DrawCard();

                    if (deckP2.Any())
                        cardP2 = deckP2.DrawCard();

                    Console.Write($"P1 plays [{cardP1}] and P2 plays [{cardP2}] ");

                    var handResult = _cardComparer.CompareCards(cardP1, cardP2);

                    battleCards.Add(cardP1);
                    battleCards.Add(cardP2);

                    if (handResult == CompareState.Player1Won)
                    {
                        pileP1.AddRange(battleCards);
                        handOver = true;
                        Console.WriteLine("=> P1 Won !");
                    }
                    else if (handResult == CompareState.Player2Won)
                    {
                        pileP2.AddRange(battleCards);
                        handOver = true;
                        Console.WriteLine("=> P2 Won !");
                    }
                    else
                    {
                        deckP1 = ResetDeck(deckP1, ref pileP1);
                        deckP2 = ResetDeck(deckP2, ref pileP2);

                        if (deckP1.Any())
                            battleCards.Add(deckP1.DrawCard());
                        if (deckP2.Any())
                            battleCards.Add(deckP2.DrawCard());

                        Console.Write("=> Battle ! => ");
                    }

                    deckP1 = ResetDeck(deckP1, ref pileP1);
                    deckP2 = ResetDeck(deckP2, ref pileP2);
                }

                if (deckP1.Empty() || deckP2.Empty())
                    gameOver = true;
            }

            Console.WriteLine(deckP2.Empty() ? $"P1 won in {turnsTaken} turns" : $"P2 won in {turnsTaken} turns");

            return new GameResult
            {
                Winner = deckP2.Empty() ? 1 : 2,
                TurnsTaken = turnsTaken
            };
        }

        private static IList<string> ResetDeck(IList<string> deck, ref List<string> pile)
        {
            if (deck.Empty())
            {
                deck = pile;
                deck.Shuffle();
                pile = new List<string>();
            }

            return deck;
        }
    }
}
