using FFS.Libraries.StaticEcs;
using UnityEngine;

namespace Game.Movement
{
  public struct CurrentPosition : IComponent
  {
    public Vector3 Value;
  }
}
