using System.Collections;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;

namespace Lab.Scripts.UI
{
public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject settingsMenu;

    private IEnumerator Start()
    {
        // Wait for the localization system to initialize
        yield return LocalizationSettings.InitializationOperation;
        
        if (PlayerPrefs.HasKey("Language"))
        {
            var code = PlayerPrefs.GetString("Language");
            
            if (string.IsNullOrEmpty(code)) yield break;
            var locale = LocalizationSettings.AvailableLocales.Locales.Find(locale => locale.Identifier.Code == code);

            LocalizationSettings.SelectedLocale = locale;
        }
        else
        {
            PlayerPrefs.SetString("Language", LocalizationSettings.SelectedLocale.Identifier.Code);
        }
    }


    public void NewGame()
    {
        SceneManager.LoadScene("DevelopScene");
    }
    
    public void Settings()
    {
        settingsMenu.SetActive(true);
        SettingsMenu.IsInMainMenu = true;
    }
    
    public void Quit()
    {
        Application.Quit();
    }
}
}