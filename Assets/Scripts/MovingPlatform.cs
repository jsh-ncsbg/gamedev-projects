using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    Vector3 direction = Vector3.right;

    // How far it travels to each side of where it was placed
    [SerializeField]
    float distance = 3f;

    // Units per second
    [SerializeField]
    float speed = 2f;

    [SerializeField]
    bool isMoving = true;

    Vector3 startPosition;

    // Our own clock, so pausing and resuming continues from the same spot
    float moveTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoving)
        {
            return;
        }

        moveTime += Time.deltaTime;

        float offset = Mathf.PingPong(moveTime * speed + distance, distance * 2f) - distance;

        transform.position = startPosition + direction.normalized * offset;
    }

    public void Pause()
    {
        isMoving = false;
    }

    public void Resume()
    {
        isMoving = true;
    }

    public void Toggle()
    {
        isMoving = !isMoving;
    }
}
