using VContainer;
using VContainer.Unity;

namespace Game.App
{
  public class GameAppScope : LifetimeScope
  {
    protected override void Configure(IContainerBuilder builder)
    {
      builder.RegisterEntryPoint<GameApp>();
    }
  }
}
