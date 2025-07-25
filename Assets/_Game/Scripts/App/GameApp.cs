using System.Threading;
using Cysharp.Threading.Tasks;
using VContainer.Unity;

namespace Game.App
{
  public class GameApp : IAsyncStartable
  {
    public UniTask StartAsync(CancellationToken cancellation = default)
    {
      Log.Trace("App starting.");

      Log.Debug("App started.");
      return UniTask.CompletedTask;
    }
  }
}
