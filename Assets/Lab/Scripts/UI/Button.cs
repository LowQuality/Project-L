using UnityEngine;
using UnityEngine.SceneManagement;

namespace Lab.Scripts.UI
{
public class Button : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene("DevelopScene");
    }
}
}