using UnityEngine;
using UnityEngine.Localization.Components;

namespace Lab.Scripts.UI.StaticTextManager
{
public class STM_buildNumber : MonoBehaviour
{
    public LocalizeStringEvent localizeString;
    public string buildNumber = "Null";

    private void Start()
    {
        buildNumber = Application.version;
        localizeString.StringReference.RefreshString();
    }
}
}
