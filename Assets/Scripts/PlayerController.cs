using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Vector3 spawnPos = new(0, 3, 0);

    [SerializeField]
    private float moveSpeed = 5f;

    [SerializeField, Min(0f)]
    private float movementStartDelay = 3f;

    private float movementUnlockTime;

    [SerializeField]
    private float jumpForce = 10f;

    [SerializeField]
    private float gravityScale = 1f;

    [SerializeField]
    private float xRange = 3.5f;

    private Rigidbody rb;

    [SerializeField]
    InputAction moveAction;
    private Vector2 moveInput;
    private bool jumpRequested;

    [SerializeField]
    InputAction jumpAction;

    private PlayerHealth playerHealth;

    public UnityEvent OnGameFinish;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();

        // Subscribe to the OnPlayerDeath event to reset the player when they die
        playerHealth.OnPlayerDeath.AddListener(ResetPlayer);

        rb = GetComponent<Rigidbody>();

        movementUnlockTime = Time.time + movementStartDelay;

        moveAction.Enable();
        jumpAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time < movementUnlockTime)
        {
            moveInput = Vector2.zero;
            jumpRequested = false;
            return;
        }

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
        // Keep gravity active while waiting for the lasers to reach the play area.
        rb.AddForce(Physics.gravity * gravityScale, ForceMode.Acceleration);

        if (Time.time < movementUnlockTime)
        {
            return;
        }

        Vector3 move = new(moveInput.x, 0, moveInput.y);
        move.Normalize();

        rb.MovePosition(rb.position + move * moveSpeed * Time.fixedDeltaTime);
        if (rb.position.x < -xRange)
        {
            rb.position = new Vector3(-xRange, rb.position.y, rb.position.z);
        }
        else if (rb.position.x > xRange)
        {
            rb.position = new Vector3(xRange, rb.position.y, rb.position.z);
        }

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            Debug.Log("Player has reached the finish line!");
            OnGameFinish?.Invoke();
        }
    }
}
