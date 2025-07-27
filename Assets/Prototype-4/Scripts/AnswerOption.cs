using UnityEngine;

public class AnswerOption : MonoBehaviour
{
    private bool isCorrect;

    public void SetAnswer(bool correct)
    {
        isCorrect = correct;
    }

    void OnMouseDown()
    {
        if (isCorrect)
        {
            Debug.Log("Correct!");
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Try again!");
        }
    }
}
