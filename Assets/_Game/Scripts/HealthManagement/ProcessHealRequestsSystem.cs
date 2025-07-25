using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace Game.HealthManagement
{
  public class ProcessHealRequestsSystem : IFrameSystem
  {
    public void Update()
    {
      foreach (var entity in GameWorld.QueryEntities.For<All<HealRequest>>()) {
        ProcessRequest(entity);

        entity.Destroy();
      }
    }

    private static void ProcessRequest(World<GameWorld.World>.Entity entity)
    {
      ref var healRequest = ref entity.Ref<HealRequest>();

      var target = healRequest.Target;
      if (!target.IsActual()) {
        return;
      }

      if (!target.HasAllOf<Health>()) {
        return;
      }

      ref var health = ref target.Ref<Health>();

      health.Value = Mathf.Min(health.Value + healRequest.Amount, health.MaxValue);

      if (health.Value <= 0f || !target.HasAllOfTags<Dead>()) {
        return;
      }

      target.DeleteTag<Dead>();
      target.SetTag<Alive>();
    }
  }
}
