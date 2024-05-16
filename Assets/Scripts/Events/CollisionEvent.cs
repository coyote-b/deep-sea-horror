using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class CollisionEvent : MonoBehaviour
{
    public UnityEvent OnCollisionEnter;
    public UnityEvent OnCollisionExit;
    public UnityEvent OnCollisionStay;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnCollisionEnter?.Invoke();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        OnCollisionExit?.Invoke();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        OnCollisionStay?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnCollisionEnter?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        OnCollisionExit?.Invoke();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        OnCollisionStay?.Invoke();
    }
}
