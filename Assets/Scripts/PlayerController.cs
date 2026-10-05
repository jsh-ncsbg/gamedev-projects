using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Vector3 spawnPos = new(0, 3, 0);

    [SerializeField]
    private float moveSpeed = 5f;

    [SerializeField]
    private float jumpForce = 10f;

    private Rigidbody rb;

    [SerializeField]
    InputAction moveAction;
    private Vector2 moveInput;
    private bool jumpRequested;

    [SerializeField]
    InputAction jumpAction;

    private PlayerHealth playerHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();

        // Subscribe to the OnPlayerDeath event to reset the player when they die
        playerHealth.OnPlayerDeath.AddListener(ResetPlayer);

        rb = GetComponent<Rigidbody>();

        moveAction.Enable();
        jumpAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        moveInput = moveAction.ReadValue<Vector2>();

        // Jumping
        if (jumpAction.triggered)
        {
            jumpRequested = true;
        }
    }

    private void FixedUpdate()
    {
        Vector3 move = new(moveInput.x, 0, moveInput.y);
        move.Normalize();

        rb.MovePosition(rb.position + move * moveSpeed * Time.fixedDeltaTime);

        if (jumpRequested)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpRequested = false;
        }
    }

    public void ResetPlayer()
    {
        playerHealth.ResetHealth();
        transform.position = spawnPos;
    }
}
