using VContainer;
using VContainer.Unity;

namespace Game.Game
{
  public class GameViewScope : LifetimeScope
  {
    protected override void Configure(IContainerBuilder builder)
    {
      builder.RegisterComponentInHierarchy<GameView>();
      builder.Register<IInitializable, GameLoop>(Lifetime.Singleton).AsSelf();
    }
  }
}
