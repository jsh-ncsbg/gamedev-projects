using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private Vector3 offset;

    private void LateUpdate()
    {
        Vector3 target = new(player.transform.position.x, 0, player.transform.position.z);
        transform.position = target + offset;
    }
}
