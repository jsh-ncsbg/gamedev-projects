using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField]
    Vector3 axis = Vector3.up;

    // Degrees per second; negative spins the other way
    [SerializeField]
    float speed = 90f;

    [SerializeField]
    bool isSpinning = true;

    // Update is called once per frame
    void Update()
    {
        if (!isSpinning)
        {
            return;
        }

        transform.Rotate(axis, speed * Time.deltaTime, Space.Self);
    }

    public void Pause()
    {
        isSpinning = false;
    }

    public void Resume()
    {
        isSpinning = true;
    }

    public void Toggle()
    {
        isSpinning = !isSpinning;
    }
}
