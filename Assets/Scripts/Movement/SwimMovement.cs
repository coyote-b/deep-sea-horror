using UnityEngine;

/// <summary>
/// A component for underwater movement.
/// </summary>
public class SwimMovement : MonoBehaviour
{
    private Vector2 _lastAppliedForce = new Vector2(0, 1);

    [SerializeField]
    Rigidbody2D _body;

    [SerializeField]
    float _movementSpeed;

    [SerializeField]
    float _boostSpeed;

    /// <summary>
    /// Applies force to the RigidBody according to the force specified.
    /// </summary>
    /// <param name="force">The direction of force.</param>
    public void Swim(Vector2 force)
    {
        Move(force, _movementSpeed);
    }

    /// <summary>
    /// Applies force to the RigidBody according to the boost speed and the last applied force.
    /// </summary>
    public void Boost()
    {
        Move(_lastAppliedForce, _boostSpeed);
    }

    /// <summary>
    /// Applies force to the RigidBody.
    /// </summary>
    /// <param name="force">The direction of force.</param>
    /// <param name="speed">The speed multiplier of the force.</param>
    private void Move(Vector2 force, float speed)
    {
        _body.AddForce(new Vector2(force.x * speed, force.y * speed));
        _lastAppliedForce = force;
    }
}
