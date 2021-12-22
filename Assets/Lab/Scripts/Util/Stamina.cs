using System;
using UnityEngine;

namespace Lab.Scripts.Util
{
public class Stamina : MonoBehaviour
{
    [SerializeField] private float spMax;
    private float _currentSp;

    [SerializeField] private float spIncreaseSpeed;

    [SerializeField] private int spRechargeTime;
    private int _currentSpRechargeTime;

    private bool _spUsed;

    private void Start()
    {
        _currentSp = spMax;
    }

    private void FixedUpdate()
    {
        SpRechargeTime();
        SpRecover();
    }

    public void DecreaseStamina(float count)
    {
        _spUsed = true;
        _currentSpRechargeTime = 0;

        if (_currentSp - count > 0)
        {
            _currentSp -= count;
        }
        else
            _currentSp = 0;
    }

    private void SpRechargeTime()
    {
        if (!_spUsed) return;
        if (_currentSpRechargeTime < spRechargeTime)
            _currentSpRechargeTime++;
        else
            _spUsed = false;
    }

    private void SpRecover()
    {
        if (!_spUsed && _currentSp < spMax)
        {
            _currentSp += spIncreaseSpeed;
        }
    }

    public float GetCurrentSp()
    {
        return _currentSp;
    }

    public void IncreaseSp(float increase)
    {
        _currentSp += increase;
    }

    public void SetSp(float increase)
    {
        _currentSp = increase > spMax ? spMax : increase;
    }
}
}