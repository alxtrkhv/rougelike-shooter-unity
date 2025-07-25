using System;
using VContainer.Unity;

namespace Game.Game
{
  public class GameLoop : IInitializable, IDisposable
  {
    public bool IsPlaying { get; private set; }

    public void Initialize() { }

    public void Play()
    {
      if (IsPlaying) {
        return;
      }
    }

    public void Pause()
    {
      if (!IsPlaying) {
        return;
      }
    }

    public void Dispose() { }
  }
}
