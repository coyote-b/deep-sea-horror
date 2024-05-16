using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenUI : MonoBehaviour
{
    private int _currentWholeBubbles;

    [SerializeField]
    private List<BubbleUI> _bubbles;

    private void Start()
    {
        _currentWholeBubbles = _bubbles.Count;
    }

    public void DecreaseOxygenUI(float percentage)
    {
        if (percentage / 10 <= _currentWholeBubbles - 1)
        {
           StartCoroutine( _bubbles[_currentWholeBubbles - 1].Pop());
            _currentWholeBubbles--;
        }
    }

    public void IncreaseOxygenUI(float percentage)
    {
        float increaseCount = (int)(percentage / 10) - _currentWholeBubbles;

        if (increaseCount < 0)
            return;
        
        for (int i = 0; i < increaseCount; i++)
        {
            StartCoroutine(_bubbles[_currentWholeBubbles].Blow());
            _currentWholeBubbles++;
        }
    }
}
