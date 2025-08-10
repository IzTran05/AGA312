using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuP1 : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Prototype 1");
    }

    public void ReturnToMainTitle()
    {
        SceneManager.LoadScene("MainTitleScreen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
