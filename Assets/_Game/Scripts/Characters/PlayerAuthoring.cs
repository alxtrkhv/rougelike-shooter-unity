using Game.Movement;

namespace Game.Characters
{
  public class PlayerAuthoring : Authoring
  {
    protected override GameWorld.Entity OnBake()
    {
      var entity = GameWorld.Entity.New(
        new Speed { Value = 2f, }
      );

      entity.SetTag<Character, Player>();

      return entity;
    }
  }
}
