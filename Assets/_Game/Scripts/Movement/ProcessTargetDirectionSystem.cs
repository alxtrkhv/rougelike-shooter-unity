using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace Game.Movement
{
  public class ProcessTargetDirectionSystem : IFrameSystem
  {
    public void Update()
    {
      foreach (var entity in GameWorld.QueryEntities.For<All<CurrentPosition, TargetDirection, Speed>>()) {
        ref var currentPosition = ref entity.Ref<CurrentPosition>();
        ref var targetDirection = ref entity.Ref<TargetDirection>();
        ref var speed = ref entity.Ref<Speed>();

        var newPosition = currentPosition.Value + targetDirection.Value * speed.Value * Time.deltaTime;
        entity.Add<NewPosition>().Value = newPosition;
      }
    }
  }
}
