using Game.Movement;

namespace Game.Player
{
  public class PlayerAuthoring : Authoring
  {
    protected override GameWorld.Entity OnBake()
    {
      var entity = GameWorld.Entity.New(
        new Speed { Value = 2f, }
      );

      entity.SetTag<Player>();

      return entity;
    }
  }
}
