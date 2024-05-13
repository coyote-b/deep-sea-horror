using System.Collections;
using UnityEngine;

/// <summary>
/// A component for underwater movement.
/// </summary>
public class SwimMovement : MonoBehaviour
{
    private Vector2 _lastAppliedForce = new Vector2(0, 1);

    [SerializeField]
    private Rigidbody2D _body;

    [SerializeField]
    private float _movementSpeed;

    [SerializeField]
    private float _boostSpeed;

    public float StoppingDistance;

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

    public IEnumerator SwimToPoint(Transform point)
    {
        Vector2 direction = (transform.position - point.position).normalized;

        while (Vector2.Distance(transform.position, point.position) > StoppingDistance)
        {
            Move(direction, _movementSpeed);

            yield return null;
        }
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
