using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// A component for the player character, the diver.
/// </summary>
public class Diver : MonoBehaviour
{
    [SerializeField]
    private SwimMovement _movement;

    [SerializeField]
    private Oxygen _oxygen;

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
    public void OxygenBoost(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _movement.Boost();
            _oxygen.BoostReduce();
        }
    }
}
