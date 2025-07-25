using Viewigation.Routes;
using Viewigation.Views;

namespace Game.Game
{
  public class GameScreen : UnityRoute<GameView>
  {
    public GameScreen() : base("Screen/Game", false) { }
  }

  public class GameView : UnityView { }
}
