using UnityEngine;
using UnityEngine.SceneManagement;

public class Sceneswitcher : MonoBehaviour
{
    public void LoadNextScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadNextMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
