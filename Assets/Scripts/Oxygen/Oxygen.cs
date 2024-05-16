using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Oxygen : MonoBehaviour
{
    private float _currentOxygen;

    [SerializeField]
    private float _maxOxygen;

    [SerializeField]
    private float _depletionRate;

    [SerializeField]
    private float _depletionAmount;

    [SerializeField]
    private float _boostDepletionAmount;

    //TODO: Remove this and replace with actual UI once Teddy finishes that
    [SerializeField]
    private TextMeshProUGUI _oxygenMeter;

    [SerializeField]
    private Item _oxygenReplenish;

    public UnityEvent<float> OnOxygenLevelDecreased;
    
    void Start()
    {
        // TODO: Fix magic numbers...
        _oxygenReplenish.OnItemUsed += () => { IncreaseOxygen(50); };

        _currentOxygen = _maxOxygen;
        _oxygenMeter.text = _currentOxygen.ToString();
        StartCoroutine(DepleteOxygenOverTime());
    }

    public void BoostReduce()
    {
        DepleteOxygen(_boostDepletionAmount);
    }

    public void DepleteOxygen(float depletionAmount)
    {
        if (_currentOxygen <= 0)
            return;

        _currentOxygen -= depletionAmount;
        _oxygenMeter.text = _currentOxygen.ToString();
        OnOxygenLevelDecreased?.Invoke(_currentOxygen);
    }

    public void IncreaseOxygen(float increaseAmount)
    {
        _currentOxygen += increaseAmount;

        if (_currentOxygen > _maxOxygen)
            _currentOxygen = _maxOxygen;

        _oxygenMeter.text = _currentOxygen.ToString();
    }

    private IEnumerator DepleteOxygenOverTime()
    {
        while (_currentOxygen > 0)
        {
            yield return new WaitForSeconds(_depletionRate);
            DepleteOxygen(_depletionAmount);
        }
    }
}
