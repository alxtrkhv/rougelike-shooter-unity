using Game.Characters;
using Game.HealthManagement;
using Game.Movement;
using UnityEngine;

namespace Game
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

      Entity.Add(
        new TransformLink { Value = transform },
        new CurrentPosition { Value = transform.localPosition },
        new AuthoringLink { Value = this, }
      );

      if (Entity.HasAllOfTags<Character>()) {
        Entity.SetTag<Alive>();
        Entity.Add<Health>(new() { Value = 10f, MaxValue = 10f, });
      }
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
