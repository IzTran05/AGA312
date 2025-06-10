using System;
using UnityEngine;
using UnityEngine.InputSystem;

/*public class InputManager : MonoBehaviour
{
    public InputActionAsset inputActions;
    private InputAction moveAction, jumpAction;

    //event setup
    public static Action<Vector2> OnMove = null;
    public static Action OnJump = null;


    private void //Awake()
    {/*
        moveAction = inputActions.FindActionMap("Player").FindAction("Move");

        inputActions.FindActionMap("Player").FindAction("Jump").performed += (context) =>
        {
            if (context.action.WasPressedThisFrame())
                OnJump?.Invoke();
        }


    }

    private void Update()
    {
        Vector2 move = moveAction.ReadValue<Vector3>();
        OnMove?.Invoke(move);
    }

}*/