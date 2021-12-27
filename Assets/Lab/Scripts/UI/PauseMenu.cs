using Lab.Scripts.Player;
using UnityEngine;

namespace Lab.Scripts.UI
{
public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject settingsMenu;
    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Escape)) return;
        if (!CameraMovement.isPaused)
        {
            CameraMovement.isPaused = true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            CameraMovement.isPaused = false;
            pauseMenu.SetActive(false);
            settingsMenu.SetActive(false);
            Time.timeScale = 1f;
        }
    }
    
    public void ClickResume()
    {
        CameraMovement.isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    
    public void ClickSettings()
    {
        settingsMenu.SetActive(true);
        SettingsMenu.IsInMainMenu = true;
    }
    
    public void ClickQuit()
    {
        Application.Quit();
    }
}
}