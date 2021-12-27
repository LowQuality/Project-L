using Lab.Scripts.Util;
using UnityEngine;
using UnityEngine.Localization.Components;

namespace Lab.Scripts.UI.DynamicTextManager
{
public class DTM_Stamina : MonoBehaviour
{
    private static Stamina _stamina;
    public LocalizeStringEvent localizeString;
    public int currentStamina;

    private void OnEnable()
    {
        _stamina = FindObjectOfType<Stamina>();
    }

    private void Update()
    {
        currentStamina = (int)_stamina.GetCurrentSp();
        localizeString.StringReference.RefreshString();
    }
}
}
