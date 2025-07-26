using FFS.Libraries.StaticEcs;
using Game.AI;
using Game.Characters;
using Game.HealthManagement;
using Game.Movement;

namespace Game
{
  public abstract class GameWorld : World<GameWorld.Tag>
  {
    public struct Tag : IWorldType { }

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
      RegisterTagType<NPC>();
      RegisterTagType<Enemy>();

      RegisterComponentType<Health>();
      RegisterComponentType<DamageRequest>();
      RegisterComponentType<HealRequest>();
      RegisterTagType<Alive>();
      RegisterTagType<Dead>();

      RegisterComponentType<AuthoringLink>();

      RegisterComponentType<Behavior>();
    }
  }

  public abstract class TickSystems : World<GameWorld.Tag>.Systems<TickSystems.Tag>
  {
    public struct Tag : ISystemsType { }
  }

  public abstract class FrameSystems : World<GameWorld.Tag>.Systems<FrameSystems.Tag>
  {
    public struct Tag : ISystemsType { }
  }
}
