using FFS.Libraries.StaticEcs;

namespace Game
{
  public class BakeAuthoringsSystem : IInitSystem
  {
    private readonly GameView _gameView;

    public BakeAuthoringsSystem(GameView gameView)
    {
      _gameView = gameView;
    }

    public void Init()
    {
      var authorings = _gameView.GetComponentsInChildren<Authoring>(includeInactive: true);

      foreach (var authoring in authorings) {
        authoring.BakeEntity();
      }
    }
  }
}
