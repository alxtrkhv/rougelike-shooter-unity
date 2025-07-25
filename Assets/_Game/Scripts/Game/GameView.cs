using System.Threading;
using Cysharp.Threading.Tasks;
using VContainer;
using Viewigation.Routes;
using Viewigation.VContainer;
using Viewigation.Views;

namespace Game.Game
{
  public class GameScreen : UnityRoute<GameView>, ICustomScopeProvider<GameViewScope>
  {
    public GameScreen() : base("Screen/Game", false) { }
  }

  public class GameView : UnityView
  {
    private GameLoop _gameLoop = null!;

    [Inject]
    public void Inject(GameLoop gameLoop)
    {
      _gameLoop = gameLoop;
    }

    protected override UniTask OnShow(bool animated, CancellationToken cancellation = default)
    {
      _gameLoop.Play();

      return UniTask.CompletedTask;
    }

    protected override void OnSuspend(bool state)
    {
      if (state) {
        _gameLoop.Pause();
      } else {
        _gameLoop.Play();
      }
    }

    protected override UniTask OnHide(bool animated, CancellationToken cancellation = default)
    {
      _gameLoop.Pause();

      return UniTask.CompletedTask;
    }
  }
}
