using UnityEngine;

public class EnemyAnswerOption : MonoBehaviour
{
    private bool isCorrect;
    private MathEnemy enemy;

    public void SetAnswer(bool correct, MathEnemy parentEnemy)
    {
        isCorrect = correct;
        enemy = parentEnemy;
    }

    void OnMouseDown()
    {
        if (isCorrect)
        {
            enemy.Defeat();
        }
        else
        {
            enemy.WrongAnswer();
        }
    }
}
