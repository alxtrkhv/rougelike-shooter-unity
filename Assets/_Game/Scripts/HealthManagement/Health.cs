using FFS.Libraries.StaticEcs;

namespace Game.HealthManagement
{
  public struct Health : IComponent
  {
    public float Value;
    public float MaxValue;
  }
}
