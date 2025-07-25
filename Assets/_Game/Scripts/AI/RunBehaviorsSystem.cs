using FFS.Libraries.StaticEcs;

namespace Game.AI
{
  public class RunBehaviorsSystem : IFrameSystem
  {
    public void Update()
    {
      foreach (var entity in GameWorld.QueryEntities.For<All<Behavior>>()) {
        ref var behavior = ref entity.Ref<Behavior>();

        behavior.Value.Tick(entity);
      }
    }
  }
}
