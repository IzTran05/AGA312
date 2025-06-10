using UnityEngine;

public class Playground : GameBehaviour
{

    public GameObject player;

    void Start()
    {
        ObjectX.ScaleObjectToZero(player);
        ExecuteAfterSeconds(1, () =>
            {
                SetupPlayer();
            });

        ExecuteAfterFrames(3, () => print("3 frames later..."));

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space));
        player.GetComponent<Renderer>().material.color = ColorX.GetRandomColour();
    }

    private void SetupPlayer()
    {
        player.GetComponent<Renderer>().material.color = ColorX.GetRandomColour();
        ObjectX.ScaleObjectToValue(player);
    }

    private void OnMove(Vector2 _move)
    {
        print(_move);
        player.transform.position += new Vector3(_move.x, 0, _move.y);
    }

    private void OnJump()
    {
        print("Ima Mario! WAAAAAHOOOOOO")
    }


    private void OnEnable()
    {
        InputManager.OnMove += OnMove;
        InputManager.OnJump += OnJump;
    }

    private void OnDisabled()
    {
        InputManager.OnMove -= OnMove;
        InputManager.OnJump -= OnJump;
    }

}
