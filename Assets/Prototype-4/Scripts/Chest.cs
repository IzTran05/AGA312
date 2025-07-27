using UnityEngine;

public class Chest : MonoBehaviour
{
    public MathQuestionGenerator mathGenerator;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            mathGenerator.GenerateNewQuestion();
            gameObject.SetActive(false); // hide chest after interaction
        }
    }
}
