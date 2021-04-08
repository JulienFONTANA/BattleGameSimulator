using BattleCardSimulator.Interfaces;
using Ninject.Modules;

namespace BattleCardSimulator
{
    public class InjectionModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IBattleGame>().To<BattleGame>();
            Bind<ICardComparer>().To<CardComparer>();
            Bind<IDeckService>().To<DeckService>();
        }
    }
}
