using Viewigation.Routes;
using Viewigation.Views;

namespace Game.App
{
  public class SplashScreen : UnityRoute<LoadingView>
  {
    public SplashScreen() : base(null, false) { }
  }

  public class LoadingView : UnityView { }
}
