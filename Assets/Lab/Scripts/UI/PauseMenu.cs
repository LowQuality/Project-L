using Lab.Scripts.Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Lab.Scripts.UI
{
public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject settingsMenu;
    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Escape)) return;
        if (!CameraMovement.IsPaused)
        {
            CameraMovement.IsPaused = true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            CameraMovement.IsPaused = false;
            pauseMenu.SetActive(false);
            settingsMenu.SetActive(false);
            Time.timeScale = 1f;
        }
    }
    
    public void ClickResume()
    {
        CameraMovement.IsPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    
    public void ClickSettings()
    {
        settingsMenu.SetActive(true);
        SettingsMenu.IsInMainMenu = true;
    }
    
    public void ClickGoTitle()
    {
        SceneManager.LoadScene("Title"); 
        Time.timeScale = 1f;
    }
    
    public void ClickQuit()
    {
        Application.Quit();
    }
}
}