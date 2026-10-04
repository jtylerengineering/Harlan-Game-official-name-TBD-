using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;
    private bool lerpCrouch;
    private bool crouching;
    private bool running;
    private float p;


    public float moveSpeed = 5f;
    public float gravity = -9.8f;
    public float jumpHeight = 2.5f;
    public float crouchTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;

        if (lerpCrouch)
        {
            crouchTimer += Time.deltaTime;
            p *= p;
            if (crouching)
            {
                controller.height = Mathf.Lerp(controller.height, 1, p);
            }
            else
            {
                controller.height = Mathf.Lerp(controller.height, 2, p);
            }

            if (p > 1)
            {
                lerpCrouch = false;
                crouchTimer = 0f;
            }
        }
    }
//inputs from Input script are used here
    public void ProcessMove(Vector2 input){ 
        Vector3 moveDirect = Vector3.zero;
        moveDirect.x = input.x;
        moveDirect.z = input.y;
        controller.Move(transform.TransformDirection(moveDirect) * moveSpeed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        if(isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }
        controller.Move(playerVelocity * Time.deltaTime);

    }

    public void Jump()
    {
        if( isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2.5f * gravity);
        }
    }

    public void Crouch()
    {
        crouching = !crouching;
        crouchTimer = 0;
        lerpCrouch = true;
    }

    public void Run()
    {
        running = !running;
        if (running)
        {
            moveSpeed = 8f;
        }
        else
        {
            moveSpeed = 5f;
        }
    }
}
