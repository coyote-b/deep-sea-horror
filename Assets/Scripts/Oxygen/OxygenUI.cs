using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenUI : MonoBehaviour
{
    private int _currentWholeBubbles;
    private float _animatorSpeed;

    [SerializeField]
    private List<BubbleUI> _bubbles;

    [SerializeField]
    private Animator _animator;

    private void Start()
    {
        _currentWholeBubbles = _bubbles.Count;
        _animatorSpeed = _animator.speed;
    }

    public void DecreaseOxygenUI(float percentage)
    {
        if (percentage / 10 <= _currentWholeBubbles - 1)
        {
            //PauseAnimator();
            StartCoroutine(_bubbles[_currentWholeBubbles - 1].Pop());
            _currentWholeBubbles--;
            //ResumeAnimator();
        }
    }

    public void IncreaseOxygen(float percentage)
    {

    }

    // Doesn't seem like there's a better way to do this??
    private void PauseAnimator()
    {
        _animator.speed = 0f;
    }

    private void ResumeAnimator()
    {
        _animator.speed = _animatorSpeed;
    }
}
