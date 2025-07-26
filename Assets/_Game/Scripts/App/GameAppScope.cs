using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using Viewigation.Navigation;

namespace Game.App
{
  public class GameAppScope : LifetimeScope
  {
    [Header("Config")]
    [SerializeField]
    private List<NavigationLayerConfig> _navigationLayerConfigs = null!;

    protected override void Configure(IContainerBuilder builder)
    {
      builder.RegisterEntryPoint<GameApp>();

      var navigation = INavigation.Builder()
        .WithAddressables()
        .WithVContainer(builder)
        .WithMonoLifecycle()
        .AddLayerConfigs(_navigationLayerConfigs)
        .Create();

      builder.Register<INavigation>(_ => navigation!, Lifetime.Singleton);
    }
  }
}
