using Game.AI;
using Game.Movement;

namespace Game.Characters
{
  public class EnemyAuthoring : Authoring
  {
    protected override GameWorld.Entity OnBake()
    {
      var entity = GameWorld.Entity.New(
        new Speed { Value = 1.5f, },
        new Behavior { Value = new EnemyBehavior(), }
      );

      entity.SetTag<Character, NPC, Enemy>();

      return entity;
    }
  }
}
