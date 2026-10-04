using UnityEngine;
using UnityEngine.InputSystem;

public class Input : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.OnFeetActions onFeet;
    private PlayerMovement move;
    private PlayerLook look;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        playerInput = new PlayerInput();
        onFeet = playerInput.OnFeet;
        move = GetComponent<PlayerMovement>();
        look = GetComponent<PlayerLook>();

        onFeet.jump.performed += ctx => move.Jump();
        onFeet.crouch.performed += ctx => move.Crouch();
        onFeet.Run.performed += ctx =>move.Run();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //make the player move along x and z axis
        move.ProcessMove(onFeet.walk.ReadValue<Vector2>());
    }

    void LateUpdate()
    {
        look.ProcessLook(onFeet.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        onFeet.Enable();
    }
    private void OnDisable()
    {
        onFeet.Disable();
    }
}
