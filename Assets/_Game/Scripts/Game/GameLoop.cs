using System;
using System.Collections.Generic;
using FFS.Libraries.StaticEcs;
using VContainer.Unity;

namespace Game.Game
{
  public class GameLoop : IInitializable, IDisposable, ITickable, IFixedTickable
  {
    private readonly IReadOnlyList<IFrameSystem> _frameSystems;
    private readonly IReadOnlyList<ITickSystem> _tickSystems;
    private readonly IReadOnlyList<ICallOnceSystem> _callOnceSystems;

    public GameLoop(IReadOnlyList<IFrameSystem> frameSystems, IReadOnlyList<ITickSystem> tickSystems,
      IReadOnlyList<ICallOnceSystem> callOnceSystems)
    {
      _frameSystems = frameSystems;
      _tickSystems = tickSystems;
      _callOnceSystems = callOnceSystems;
    }

    public bool IsPlaying { get; private set; }

    public void Initialize()
    {
      var worldConfig = WorldConfig.Default();

      GameWorld.Create(worldConfig);

      GameWorld.Initialize();

      GameWorld.FrameSystems.Create();
      GameWorld.TickSystems.Create();

      foreach (var callOnceSystem in _callOnceSystems) {
        GameWorld.FrameSystems.AddCallOnce(callOnceSystem);
      }

      foreach (var frameSystem in _frameSystems) {
        GameWorld.FrameSystems.AddUpdate(frameSystem);
      }

      foreach (var tickSystem in _tickSystems) {
        GameWorld.TickSystems.AddUpdate(tickSystem);
      }

      GameWorld.FrameSystems.Initialize();
      GameWorld.TickSystems.Initialize();
    }

    public void Play()
    {
      if (IsPlaying) {
        return;
      }

      IsPlaying = true;
    }

    public void Pause()
    {
      if (!IsPlaying) {
        return;
      }

      IsPlaying = false;
    }

    public void Tick()
    {
      if (!IsPlaying) {
        return;
      }

      GameWorld.FrameSystems.Update();
    }

    public void FixedTick()
    {
      if (!IsPlaying) {
        return;
      }

      GameWorld.TickSystems.Update();
    }

    public void Dispose()
    {
      IsPlaying = false;

      GameWorld.TickSystems.Destroy();
      GameWorld.FrameSystems.Destroy();
      GameWorld.Destroy();
    }
  }
}
