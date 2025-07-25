using FFS.Libraries.StaticEcs;

namespace Game.HealthManagement
{
  public struct DamageRequest : IComponent
  {
    public float Amount;
    public GameWorld.Entity Source;
    public GameWorld.Entity Target;
  }
}
