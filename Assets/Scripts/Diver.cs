using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Diver : MonoBehaviour
{
    [SerializeField]
    SwimMovement _movement;

    public void Swim(InputAction.CallbackContext context)
    {
        _movement.Swim(context.ReadValue<Vector2>()); 
    }
}
