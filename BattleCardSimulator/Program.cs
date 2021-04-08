using System;
using BattleCardSimulator.Interfaces;
using Ninject;

namespace BattleCardSimulator
{
    public class Program
    {
        private static void Main()
        {
            Console.ForegroundColor = ConsoleColor.White;
            var kernel = new StandardKernel(new InjectionModule());
            var service = kernel.Get<IBattleGame>();

            var scoreP1 = 0;
            var totalTurnsP1 = 0;
            var scoreP2 = 0;
            var totalTurnsP2 = 0;
            for (int i = 0; i < 1000; i++)
            {
                var gameResult = service.Play();
                if (gameResult.Winner == 1)
                {
                    scoreP1++;
                    totalTurnsP1 += gameResult.TurnsTaken;
                }
                if (gameResult.Winner == 2)
                {
                    scoreP2++;
                    totalTurnsP2 += gameResult.TurnsTaken;
                }
            }
            Console.WriteLine(Environment.NewLine + $"Over 1000 games, P1 won {scoreP1} in an average of {totalTurnsP1/scoreP1} turns");
            Console.WriteLine(Environment.NewLine + $"Over 1000 games, P2 won {scoreP2} in an average of {totalTurnsP2/scoreP2} turns");
        }
    }
}
