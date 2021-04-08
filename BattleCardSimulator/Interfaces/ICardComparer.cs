namespace BattleCardSimulator.Interfaces
{
    public interface ICardComparer
    {
        CompareState CompareCards(string cardP1, string cardP2);
    }
}