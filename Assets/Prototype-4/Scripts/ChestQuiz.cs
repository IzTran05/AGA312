using UnityEngine;
using TMPro;

public class ChestQuiz : MonoBehaviour
{
    public GameObject chestUI;
    public TextMeshPro questionText;
    public GameObject[] answerButtons;
    public Animator anim;

    private int correctAnswer;

    void Start()
    {
        chestUI.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GenerateQuestion();
            //chestUI.SetActive(true);
            anim.SetTrigger("Show");
        }
    }

    void GenerateQuestion()
    {
        int a = Random.Range(1, 10);
        int b = Random.Range(1, 10);
        correctAnswer = a + b;
        questionText.text = $"What is {a} + {b}?";

        int correctIndex = Random.Range(0, answerButtons.Length);

        for (int i = 0; i < answerButtons.Length; i++)
        {
            int value = (i == correctIndex) ? correctAnswer : Random.Range(1, 20);
            TextMeshPro answerText = answerButtons[i].GetComponentInChildren<TextMeshPro>();
            answerText.text = value.ToString();

            answerButtons[i].GetComponent<AnswerOption>().SetAnswer(value == correctAnswer);
            answerButtons[i].SetActive(true);
        }
    }

   
}
