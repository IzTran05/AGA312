using TMPro;
using UnityEngine;

public class MathEnemy : MonoBehaviour
{
    public GameObject questionUI;
    public TextMeshPro questionText;
    public GameObject[] answerButtons;

    private int correctAnswer;

    void Start()
    {
        questionUI.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GenerateQuestion();
            questionUI.SetActive(true);
        }
    }

    void GenerateQuestion()
    {
        int a = Random.Range(5, 20);
        int b = Random.Range(1, a); // ensure result is not negative
        correctAnswer = a - b;

        questionText.text = $"What is {a} - {b}?";

        int correctIndex = Random.Range(0, answerButtons.Length);
        for (int i = 0; i < answerButtons.Length; i++)
        {
            int value = (i == correctIndex) ? correctAnswer : Random.Range(1, 20);
            TextMeshPro btnText = answerButtons[i].GetComponentInChildren<TextMeshPro>();
            btnText.text = value.ToString();

            answerButtons[i].GetComponent<EnemyAnswerOption>().SetAnswer(value == correctAnswer, this);
        }
    }

    public void Defeat()
    {
        Debug.Log("Enemy defeated!");
        gameObject.SetActive(false);         // Hide the enemy
        questionUI.SetActive(false);         // Hide the question UI
        GameManager4.Instance.AddPoint();     // Reward the player
    }

    public void WrongAnswer()
    {
        Debug.Log("Wrong! Try again.");
    }
}
