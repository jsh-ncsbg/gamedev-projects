using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    Transform target;

    [SerializeField]
    float smoothTime = 0.15f;

    Vector3 offset;
    Vector3 velocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (target == null)
        {
            target = GameObject.FindWithTag("Player").transform;
        }

        // Keep whatever distance the camera was placed at in the scene
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, target.position + offset, ref velocity, smoothTime);
    }
}
