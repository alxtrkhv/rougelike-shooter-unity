using FFS.Libraries.StaticEcs;
using Game.AI;
using Game.Characters;
using Game.Movement;

namespace Game
{
  public abstract class GameWorld : World<GameWorld.World>
  {
    public struct World : IWorldType { }

    public struct Frame : ISystemsType { }

    public struct Tick : ISystemsType { }

    public abstract class FrameSystems : Systems<Frame> { }

    public abstract class TickSystems : Systems<Tick> { }

    public static void RegisterComponents()
    {
      RegisterComponentType<TransformLink>();
      RegisterComponentType<CurrentPosition>();
      RegisterComponentType<NewPosition>();
      RegisterComponentType<Speed>();
      RegisterComponentType<TargetPosition>();
      RegisterComponentType<TargetDirection>();

      RegisterTagType<Character>();
      RegisterTagType<Player>();

      RegisterComponentType<AuthoringLink>();

      RegisterComponentType<Behavior>();
    }
  }
}
