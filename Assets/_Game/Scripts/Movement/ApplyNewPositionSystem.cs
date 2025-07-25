using FFS.Libraries.StaticEcs;

namespace Game.Movement
{
  public class ApplyNewPositionSystem : IFrameSystem
  {
    public void Update()
    {
      foreach (var entity in GameWorld.QueryEntities.For<All<TransformLink, CurrentPosition, NewPosition>>()) {
        ref var transformLink = ref entity.Ref<TransformLink>();
        ref var currentPosition = ref entity.Ref<CurrentPosition>();
        ref var newPosition = ref entity.Ref<NewPosition>();

        transformLink.Value.localPosition = newPosition.Value;
        currentPosition.Value = newPosition.Value;

        entity.Delete<NewPosition>();
      }
    }
  }
}
