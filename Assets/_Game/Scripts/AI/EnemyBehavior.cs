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
      var checkPlayerAlive = Builder.Lambda(entity => {
          var playerAlive = GameWorld.QueryEntities.For<TagAll<Player>>().First(out _);
          if (playerAlive) {
            return NodeStatus.Success;
          }

          entity.TryDelete<TargetDirection>();
          return NodeStatus.Failure;
        }
      );

      var checkDistance = Builder.Lambda(entity => {
          GameWorld.QueryEntities.For<TagAll<Player>>().First(out var playerEntity);

          ref var playerPosition = ref playerEntity.Ref<CurrentPosition>();
          ref var currentPosition = ref entity.Ref<CurrentPosition>();

          var distance = (playerPosition.Value - currentPosition.Value).magnitude;
          if (distance >= 1f) {
            return NodeStatus.Success;
          }

          entity.TryDelete<TargetDirection>();
          return NodeStatus.Failure;
        }
      );

      var followPlayer = Builder.Lambda(entity => {
          GameWorld.QueryEntities.For<TagAll<Player>>().First(out var playerEntity);

          ref var playerPosition = ref playerEntity.Ref<CurrentPosition>();
          ref var currentPosition = ref entity.Ref<CurrentPosition>();

          var direction = (playerPosition.Value - currentPosition.Value).normalized;

          entity.Put(new TargetDirection { Value = direction, });

          return NodeStatus.Success;
        }
      );

      Root = Builder.Sequence(
        checkPlayerAlive,
        checkDistance,
        followPlayer
      );
    }
  }
}
