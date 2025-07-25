using FFS.Libraries.StaticEcs;

namespace Game
{
  public class DestroyAuthoringSystem : IDestroySystem
  {
    public void Destroy()
    {
      foreach (var entity in GameWorld.QueryEntities.For<All<AuthoringLink>>()) {
        ref var authoringLink = ref entity.Ref<AuthoringLink>();

        authoringLink.Value.DisposeEntity();
      }
    }
  }
}
