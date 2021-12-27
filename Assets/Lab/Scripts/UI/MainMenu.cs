using UnityEngine;
using UnityEngine.SceneManagement;

namespace Lab.Scripts.UI
{
public class MainMenu : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene("DevelopScene");
    }
}
}