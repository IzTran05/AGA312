using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainTitleScreen : MonoBehaviour
{
    public void LoadGame1()
    {
        SceneManager.LoadScene("MainMenu0");
    }

    public void LoadGame2()
    {
        SceneManager.LoadScene("MainMenu1");
    }

    public void LoadGame3()
    {
        SceneManager.LoadScene("MainMenu2");
    }

    public void LoadGame4()
    {
        SceneManager.LoadScene("MainMenu4");
    }

    public void LoadGame5()
    {
        SceneManager.LoadScene("MainMenu5");
    }
    
}
