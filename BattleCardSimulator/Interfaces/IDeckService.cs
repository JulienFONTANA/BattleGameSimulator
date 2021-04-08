using System.Collections.Generic;

namespace BattleCardSimulator.Interfaces
{
    public interface IDeckService
    {
        void InitBattleGame(out IList<string> half1, out IList<string> half2);
    }
}