using UnityEngine;

namespace Game.Game
{
  public abstract class Authoring : MonoBehaviour
  {
    public GameWorld.Entity Entity { get; private set; }

    public void BakeEntity()
    {
      if (Entity.IsActual()) {
        return;
      }

      Entity = OnBake();
    }

    protected virtual GameWorld.Entity OnBake() => GameWorld.Entity.New();

    public void DisposeEntity()
    {
      if (!Entity.IsActual()) {
        return;
      }

      OnDispose();

      if (!Entity.IsActual()) {
        return;
      }

      Entity.Destroy();
    }

    protected virtual void OnDispose() => Entity.Destroy();
  }
}
