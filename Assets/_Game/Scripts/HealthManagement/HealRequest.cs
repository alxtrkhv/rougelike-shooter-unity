using FFS.Libraries.StaticEcs;

namespace Game.HealthManagement
{
  public struct HealRequest : IComponent
  {
    public float Amount;
    public GameWorld.Entity Source;
    public GameWorld.Entity Target;
  }
}
