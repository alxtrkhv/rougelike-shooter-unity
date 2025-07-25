using FFS.Libraries.StaticEcs;

namespace Game.Game
{
  public abstract class GameWorld : World<GameWorld.World>
  {
    public struct World : IWorldType { }

    public struct Frame : ISystemsType { }

    public struct Tick : ISystemsType { }

    public abstract class FrameSystems : Systems<Frame> { }

    public abstract class TickSystems : Systems<Tick> { }
  }
}
