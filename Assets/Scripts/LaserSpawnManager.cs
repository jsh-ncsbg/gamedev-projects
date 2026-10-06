using Unity.VisualScripting;
using UnityEngine;

public class LaserSpawnManager : MonoBehaviour
{
    [SerializeField]
    GameObject laserPrefab;

    [SerializeField]
    float minSpawnInterval = 1f;

    [SerializeField]
    float maxSpawnInterval = 2f;

    [SerializeField]
    Vector3 spawnPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke(nameof(SpawnLaser), Random.Range(minSpawnInterval, maxSpawnInterval));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnLaser()
    {
        if (!enabled) return;

        float rotationZ = Random.Range(0, 180f);
        float yPosition = this.spawnPosition.y + Random.Range(-4f, 2f);
        float xPosition = Random.Range(-3f, 3f);

        Vector3 newSpawnPosition = new Vector3(xPosition, yPosition, this.spawnPosition.z);
        Instantiate(laserPrefab, newSpawnPosition, laserPrefab.transform.rotation * Quaternion.Euler(0, 0, rotationZ));

        Invoke(nameof(SpawnLaser), Random.Range(minSpawnInterval, maxSpawnInterval));
    }
}
