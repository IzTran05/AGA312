using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class KeypadController : MonoBehaviour
{
    public GameObject keypadUI;
    public TMP_Text inputDisplay; 
    public string correctCode = "1234";
    public GameObject doorToOpen;
    private string currentInput = "";

    public GameObject playerController; // Reference to disable movement

    void Start()
    {
        keypadUI.SetActive(false);
    }

    public void ActivateKeypad()
    {
        keypadUI.SetActive(true);
        Time.timeScale = 0;

        Cursor.lockState = CursorLockMode.None;  // Unlock cursor
        Cursor.visible = true;

        if (playerController != null)
            playerController.SetActive(false);   // Disable movement (optional)

        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(null);
    }

    public void SubmitCode()
    {
        if (currentInput == correctCode)
        {
            doorToOpen.SetActive(false);
        }

        ExitKeypad();
    }

    public void ClearInput()
    {
        currentInput = "";
        inputDisplay.text = "";
    }

    public void AddDigit(string digit)
    {
        if (currentInput.Length < 6)
        {
            currentInput += digit;
            inputDisplay.text = currentInput;
        }
    }

    public void ExitKeypad()
    {
        keypadUI.SetActive(false);
        Time.timeScale = 1;

        Cursor.lockState = CursorLockMode.Locked;   // Re-lock cursor
        Cursor.visible = false;

        if (playerController != null)
            playerController.SetActive(true);       // Re-enable movement
    }
}
