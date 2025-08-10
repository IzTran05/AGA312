using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu2 : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("JungleJourney");
    }

    public void ReturnToMainTitle()
    {
        SceneManager.LoadScene("MainTitleScreen");
    }

}
