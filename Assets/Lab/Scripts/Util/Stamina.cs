using System;
using UnityEngine;
using UnityEngine.UI;

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
    
    // UI
    [SerializeField] private GameObject staminaUI;
    [SerializeField] private Image staminaBar;

    private void Start()
    {
        _currentSp = spMax;
    }

    private void Update()
    {
        // StaminaUI Update
        staminaBar.fillAmount = GetCurrentSp() / spMax;
        
        // Hide Stamina UI when Full Stamina
        staminaUI.SetActive((int)GetCurrentSp() != (int)spMax);
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