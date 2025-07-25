using System.Threading;
using Cysharp.Threading.Tasks;
using VContainer.Unity;
using Viewigation.Navigation;

namespace Game.App
{
  public class GameApp : IAsyncStartable
  {
    public const string UILayer = "UI";
    public const string RootLayer = "Root";

    private readonly INavigation _navigation;

    public GameApp(INavigation navigation)
    {
      _navigation = navigation;
    }

    public async UniTask StartAsync(CancellationToken cancellation = default)
    {
      Log.Trace("App starting.");
      _navigation.RegisterOnLayer<SplashScreen>(UILayer);
      _navigation.RegisterOnLayer<GameScreen>(RootLayer);

      var splashScreen = await _navigation.Load<SplashScreen>(tryFindLooseView: true, cancellation: cancellation);
      if (splashScreen == null) {
        Log.Warning("Failed to load splash screen.");
      }

      await (splashScreen?.Open<SplashScreen>(cancellation: cancellation) ?? UniTask.CompletedTask);

      var gameScreen = await _navigation.Open<GameScreen>(cancellation: cancellation);
      if (gameScreen == null) {
        Log.Error("Failed to load game screen.");
        Log.Error("App failed to start.");
        return;
      }

      await (splashScreen?.Close<SplashScreen>(cancellation: cancellation) ?? UniTask.CompletedTask);
      Log.Debug("App started.");
    }
  }
}
