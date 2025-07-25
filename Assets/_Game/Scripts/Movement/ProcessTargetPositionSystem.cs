using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace Game.Movement
{
  public class ProcessTargetPositionSystem : IFrameSystem
  {
    public void Update()
    {
      foreach (var entity in GameWorld.QueryEntities.For<All<CurrentPosition, TargetPosition, Speed>>()) {
        ref var currentPosition = ref entity.Ref<CurrentPosition>();
        ref var targetPosition = ref entity.Ref<TargetPosition>();
        ref var speed = ref entity.Ref<Speed>();

        var direction = (targetPosition.Value - currentPosition.Value).normalized;
        var distance = Vector3.Distance(currentPosition.Value, targetPosition.Value);

        if (distance <= speed.Value * Time.deltaTime) {
          entity.Add<NewPosition>().Value = targetPosition.Value;
          entity.Delete<TargetPosition>();
        } else {
          var newPosition = currentPosition.Value + direction * speed.Value * Time.deltaTime;
          entity.Add<NewPosition>().Value = newPosition;
        }
      }
    }
  }
}
