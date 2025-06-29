using UnityEngine;
using DG.Tweening;
using TMPro;

public class TweenFun : MonoBehaviour
{
    public enum Direction { North, East, South, West}
    public Transform player;
    [SerializeField] private float moveDistance = 5f;
    [SerializeField] private float moveTweenTime = 1f;
    [SerializeField] float shakeStrength = 0.4f;
    [SerializeField] private Ease moveEase;
    [SerializeField] private bool gridMovement;
    private bool isMoving = false;

    [Header("UI")]
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private int scoreBonus = 100;
    [SerializeField] private float scoreTweenTime = 1f;
  


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            MovePlayer(Direction.North);
        if (Input.GetKeyDown(KeyCode.W))
            MovePlayer(Direction.East);
        if (Input.GetKeyDown(KeyCode.W))
            MovePlayer(Direction.South);
        if (Input.GetKeyDown(KeyCode.W))
            MovePlayer(Direction.West);


    }

    private void MovePlayer(Direction _direction)
    {
        if (isMoving && gridMovement)
            return;

        switch (_direction)
        {
            case Direction.North:
                player.transform.DOLocalMoveZ(player.transform.localPosition.z + moveDistance, moveTweenTime).
                            SetEase(moveEase).
                            OnComplete(() =>
                            {
                                ScreenShake();
                                isMoving = false;
                            });
                break;
            case Direction.East:
                player.transform.DOLocalMoveX(player.transform.localPosition.z + moveDistance, moveTweenTime).
                    SetEase(moveEase).
                    OnComplete(() =>
                    {
                        ScreenShake();
                        isMoving = false;
                    });
                break;
            case Direction.South:
                player.transform.DOLocalMoveZ(player.transform.localPosition.z + moveDistance, moveTweenTime).
                    SetEase(moveEase).OnComplete(() =>
                    {
                        ScreenShake();
                        isMoving = false;
                    });
                break;
            case Direction.West:
                player.transform.DOLocalMoveX(player.transform.localPosition.z + moveDistance, moveTweenTime).
                    SetEase(moveEase).
                    OnComplete(() =>
                    {
                        ScreenShake();
                        isMoving = false;
                    });
                break;

        }
       // ChangeColour();
        ScreenShake();
    }

   // private void ChangeColour() => player.GetComponent< Renderer > ().material.DOColor(ColorX.GetRandomColor(), moveTweenTime);

    private void ScreenShake() => Camera.main.DOShakePosition(moveTweenTime / 2, shakeStrength);

    private void IncreaseScore()
    {
      //  TweenX.TweenNumbers(scoreText, score, score + scoreBonus, scoreTweenTime
    }
}
