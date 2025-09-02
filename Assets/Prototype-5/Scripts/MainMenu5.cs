using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu5 : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("BankHeist");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
