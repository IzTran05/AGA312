using UnityEngine;

public class NoteInteract : MonoBehaviour
{
    public GameObject noteUIPanel; // Assign in Inspector

    private bool isPlayerNear = false;
    private bool isNoteOpen = false;

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            ToggleNote();
        }
    }

    private void ToggleNote()
    {
        isNoteOpen = !isNoteOpen;
        noteUIPanel.SetActive(isNoteOpen);

        // Unlock/lock the cursor
        Cursor.lockState = isNoteOpen ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = isNoteOpen;

        // Pause/resume the game
        Time.timeScale = isNoteOpen ? 0f : 1f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            isPlayerNear = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            if (isNoteOpen)
                ToggleNote(); // auto-close when walking away
        }
    }

    public void CloseNote() // Optional: called from close button
    {
        if (isNoteOpen)
            ToggleNote();
    }
}
