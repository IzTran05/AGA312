using UnityEngine;
using TMPro;

public class MathQuestionGenerator : MonoBehaviour
{
    public TextMeshPro questionText;
    public GameObject[] answerButtons; // buttons with scripts attached
    private int correctAnswer;

    public void GenerateNewQuestion()
    {
        int a = Random.Range(1, 10);
        int b = Random.Range(1, 10);
        correctAnswer = a + b;
        questionText.text = $"What is {a} + {b}?";

        int correctIndex = Random.Range(0, answerButtons.Length);
        for (int i = 0; i < answerButtons.Length; i++)
        {
            int value = (i == correctIndex) ? correctAnswer : Random.Range(1, 20);
            answerButtons[i].GetComponentInChildren<TextMeshPro>().text = value.ToString();
            answerButtons[i].GetComponent<AnswerOption>().SetAnswer(value == correctAnswer);
        }

        foreach (GameObject btn in answerButtons)
        {
            btn.SetActive(true);
        }
    }
}
