using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;
    public FuseSlot[] slots;
    public GameObject doorToUnlock;

    void Awake()
    {
        Instance = this;
    }

    public void CheckPuzzleComplete()
    {
        foreach (var slot in slots)
        {
            if (!slot.isFilled)
                return;
        }

        Debug.Log("Puzzle Complete!");
        if (doorToUnlock != null)
            doorToUnlock.SetActive(false);
    }
}
