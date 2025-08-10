using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu4 : MonoBehaviour
{
    public void PlayGame ()
    {
        SceneManager.LoadScene("MathIslandAdventure");
    }

    public void QuitGame ()
    {
        Application.Quit();
    }

    public void ReturnToMainTitle()
    {
        SceneManager.LoadScene("MainTitleScreen");
    }
}
