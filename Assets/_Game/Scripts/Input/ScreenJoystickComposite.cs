using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.Utilities;

namespace Game.Input
{
  public class ScreenJoystickComposite : InputBindingComposite<Vector2>
  {
    [InputControl(layout = "Button")]
    public int button;

    [InputControl(layout = "Vector2")]
    public int start;

    [InputControl(layout = "Vector2")]
    public int current;

    public float min;
    public float max;

    public override Vector2 ReadValue(ref InputBindingCompositeContext context)
    {
      var pressed = context.ReadValueAsButton(button);
      if (!pressed) {
        return Vector2.zero;
      }

      var startingPoint = context.ReadValue<Vector2, Vector2MagnitudeComparer>(start);
      var currentPoint = context.ReadValue<Vector2, Vector2MagnitudeComparer>(current);

      var direction = currentPoint - startingPoint;
      var magnitude = direction.magnitude;

      magnitude = Mathf.Min(magnitude, max);
      if (magnitude < min) {
        return Vector2.zero;
      }

      var result = Vector2.Lerp(Vector2.zero, direction.normalized, magnitude / max);

      return result;
    }

    public override float EvaluateMagnitude(ref InputBindingCompositeContext context)
    {
      var pressed = context.ReadValueAsButton(button);
      if (!pressed) {
        return default;
      }

      return context.EvaluateMagnitude(current);
    }
  }
}
