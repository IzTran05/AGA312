using UnityEngine;

public class Chest : MonoBehaviour
{
    private MathQuestionGenerator mathGenerator;

    void Start()
    {
        mathGenerator = FindObjectOfType<MathQuestionGenerator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (mathGenerator != null)
                mathGenerator.GenerateNewQuestion();

            gameObject.SetActive(false); // hide or destroy chest
        }
    }
}
