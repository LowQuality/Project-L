using UnityEngine;

namespace Lab.Scripts.UI
{
public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject gameplayMenu;
    
    public static bool IsInMainMenu;
    private bool _isInGamePlayMenu;
    
    public void GamePlayMenu()
    {
        // Disable Main Menu
        mainMenu.SetActive(false);
        IsInMainMenu = false;
        
        // Enable Gameplay Menu
        gameplayMenu.SetActive(true);
        _isInGamePlayMenu = true;
    }

    public void Save_N_Exit()
    {
        if (IsInMainMenu)
        {
            settingsMenu.SetActive(false);
            IsInMainMenu = false;
        } else if (_isInGamePlayMenu)
        {
            IsInMainMenu = true;
            mainMenu.SetActive(true);
            
            _isInGamePlayMenu = false;
            gameplayMenu.SetActive(false);
        }
    }
}
}