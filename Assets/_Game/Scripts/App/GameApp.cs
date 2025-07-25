using System.Threading;
using Cysharp.Threading.Tasks;
using VContainer.Unity;
using Viewigation.Navigation;

namespace Game.App
{
  public class GameApp : IAsyncStartable
  {
    private readonly INavigation _navigation;

    public GameApp(INavigation navigation)
    {
      _navigation = navigation;
    }

    public async UniTask StartAsync(CancellationToken cancellation = default)
    {
      Log.Trace("App starting.");
      _navigation.RegisterOnLayer<SplashScreen>("UI");

      await _navigation.Load<SplashScreen>(tryFindLooseView: true, cancellation: cancellation);
      await _navigation.Open<SplashScreen>(cancellation: cancellation);

      // Initialization logic goes here

      await _navigation.Close<SplashScreen>(cancellation: cancellation);
      Log.Debug("App started.");
    }
  }
}
