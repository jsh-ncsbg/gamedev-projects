using UnityEngine;

public class GameController : MonoBehaviour
{
    LaserSpawnManager laserSpawnManager;

    PlayerController playerController;

    void Start()
    {
        // get player controller from the scene
        playerController = FindFirstObjectByType<PlayerController>();
        if (playerController == null)
        {
            Debug.LogError("PlayerController not found in the scene.");
            return;
        }

        // get laser spawn manager from the scene
        laserSpawnManager = FindFirstObjectByType<LaserSpawnManager>();
        if (laserSpawnManager == null)
        {
            Debug.LogError("LaserSpawnManager not found in the scene.");
            return;
        }

        playerController.OnGameFinish.AddListener(laserSpawnManager.StopSpawning);
    }
}
