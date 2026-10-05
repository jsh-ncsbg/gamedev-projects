using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private float moveSpeed = 5f;
    private float jumpForce = 10f;

    private Rigidbody rb;

    [SerializeField]
    InputAction moveAction;

    [SerializeField]
    InputAction jumpAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
}
