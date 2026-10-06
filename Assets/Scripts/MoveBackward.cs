using UnityEngine;

public class MoveBackward : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;

    [SerializeField]
    private float backwardLimit = -10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z <= backwardLimit)
        {
            Destroy(gameObject);
            return;
        }
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
    }
}
