using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwimMovement : MonoBehaviour
{
    [SerializeField]
    float _speed;

    [SerializeField]
    Rigidbody2D _body;

    public void Swim(Vector2 force)
    {
        Debug.Log(force);
        _body.AddForce(new Vector2(force.x * _speed, force.y * _speed));
    }
}
