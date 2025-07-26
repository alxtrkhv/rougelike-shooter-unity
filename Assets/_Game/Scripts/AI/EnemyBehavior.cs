using FFS.Libraries.StaticEcs;
using Game.Characters;
using Game.Movement;
using Omnihavior.Core;

namespace Game.AI
{
  public class EnemyBehavior : CustomBehavior<GameWorld.Entity>
  {
    public EnemyBehavior()
    {
      Root = Builder.Lambda(entity => {
          var playerAlive = GameWorld.QueryEntities.For<TagAll<Player>>().First(out var playerEntity);
          if (!playerAlive) {
            entity.TryDelete<TargetDirection>();
            return NodeStatus.Success;
          }

          ref var playerPosition = ref playerEntity.Ref<CurrentPosition>();
          ref var currentPosition = ref entity.Ref<CurrentPosition>();

          var distance = (playerPosition.Value - currentPosition.Value).magnitude;
          if (distance < 0.5f) {
            entity.TryDelete<TargetDirection>();
            return NodeStatus.Success;
          }

          var direction = (playerPosition.Value - currentPosition.Value).normalized;

          entity.Put(new TargetDirection { Value = direction, });

          return NodeStatus.Success;
        }
      );
    }
  }
}
