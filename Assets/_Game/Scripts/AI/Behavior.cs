using FFS.Libraries.StaticEcs;
using Omnihavior.Core;

namespace Game.AI
{
  public struct Behavior : IComponent
  {
    public IBehaviorNode<GameWorld.Entity> Value;
  }
}
