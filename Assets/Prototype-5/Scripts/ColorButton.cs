using UnityEngine;

public class ColorButton : MonoBehaviour
{
    public string colorName;
    public ColorCodePuzzle puzzleManager;
    public Light buttonLight;

    private bool playerNearby = false;

    void Awake() // Or Start()
    {
        if (buttonLight != null)
            buttonLight.enabled = false; // Always off at start
    }

    void Update()
    {
        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Pressed color: " + colorName);
            puzzleManager.PressColor(this);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            playerNearby = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            playerNearby = false;
    }

    public void TurnOnLight()
    {
        if (buttonLight != null)
            buttonLight.enabled = true;
    }

    public void TurnOffLight()
    {
        if (buttonLight != null)
            buttonLight.enabled = false;
    }
}
