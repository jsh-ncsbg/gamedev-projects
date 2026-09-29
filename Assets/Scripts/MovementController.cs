using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{

    [SerializeField]
    PlayerStats stats;

    Vector2 moveInput;

    [SerializeField]
    float moveSpeed = 5f;

    [SerializeField]
    float gravity = -32f;

    [SerializeField]
    float maxFallSpeed = 40f;

    [SerializeField]
    float jumpHeight = 0.5f;

    float verticalVelocity;

    Vector3 spawnPosition;

    //[SerializeField]
    CharacterController controller;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();

        // Wherever the player starts in the scene is the spawn point
        spawnPosition = transform.position;

        //Debug.Log(stats.Health);
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded && verticalVelocity < 0) {
            verticalVelocity = -1f;
        }

        verticalVelocity += gravity * Time.deltaTime;
        verticalVelocity = Mathf.Max(verticalVelocity, -maxFallSpeed);

        Vector3 velocity = moveSpeed * new Vector3(moveInput.x, 0, moveInput.y);
        velocity.y = verticalVelocity;

        controller.Move(velocity * Time.deltaTime);
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    public void OnJump(InputValue value)
    {
        if (value.isPressed && controller.isGrounded)
        {
            // v = sqrt(2gh)
            verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    public void Respawn()
    {
        controller.enabled = false;
        transform.position = spawnPosition;
        controller.enabled = true;

        verticalVelocity = 0f;
    }
}
