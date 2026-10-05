using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Vector3 spawnPos = new(0, 3, 0);

    private float moveSpeed = 5f;
    private float jumpForce = 10f;

    private Rigidbody rb;

    [SerializeField]
    InputAction moveAction;

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
        Vector2 moveInput = moveAction.ReadValue<Vector2>();
        Vector3 move = new(moveInput.x, 0, moveInput.y);

        transform.Translate(moveSpeed * Time.deltaTime * move);

        // Jumping
        if (jumpAction.triggered)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    public void ResetPlayer()
    {
        playerHealth.ResetHealth();
        transform.position = spawnPos;
    }
}
