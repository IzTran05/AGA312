using UnityEngine;

public class KeypadTrigger : MonoBehaviour
{
    public KeypadController keypadController;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            keypadController.ActivateKeypad();
        }
    }
}
