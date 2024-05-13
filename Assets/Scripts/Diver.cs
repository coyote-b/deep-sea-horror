using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// A component for the player character, the diver.
/// </summary>
public class Diver : MonoBehaviour
{
    [SerializeField]
    private SwimMovement _movement;

    /// <summary>
    /// Pushes the player in the direction pulled from the InputAction context.
    /// </summary>
    /// <param name="context">The InputAction context containing the direction the user pressed.</param>
    public void Swim(InputAction.CallbackContext context)
    {
        _movement.Swim(context.ReadValue<Vector2>()); 
    }

    /// <summary>
    /// Pushes the player with faster speed, for a quick boost.
    /// </summary>
    public void OxygenBoost()
    {
        _movement.Boost();
    }
}
