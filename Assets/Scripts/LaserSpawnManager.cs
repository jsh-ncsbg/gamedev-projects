using Unity.VisualScripting;
using UnityEngine;

public class LaserSpawnManager : MonoBehaviour
{
    [SerializeField]
    GameObject laserPrefab;

    [SerializeField]
    float spawnInterval = 1f;

    [SerializeField]
    float burstChance = 0.2f;

    [SerializeField]
    int burstCount = 3;

    [SerializeField]
    Vector3 spawnPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(SpawnLaser), spawnInterval, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnLaser()
    {
        if (!enabled) return;

        bool shouldBurst = Random.value < burstChance;

        int spawnCount = shouldBurst ? Random.Range(2, burstCount + 1) : 1;

        for (int i = 0; i < spawnCount; i++)
        {
            float rotationZ = Random.Range(0, 180f);
            float yPosition = this.spawnPosition.y + Random.Range(-3.5f, 3f);
            float xPosition = Random.Range(-4f, 4f);

            Vector3 newSpawnPosition = new Vector3(xPosition, yPosition, this.spawnPosition.z);
            Instantiate(laserPrefab, newSpawnPosition, laserPrefab.transform.rotation * Quaternion.Euler(0, 0, rotationZ));
        }
    }

    public void StopSpawning()
    {
        CancelInvoke(nameof(SpawnLaser));
    }
}
