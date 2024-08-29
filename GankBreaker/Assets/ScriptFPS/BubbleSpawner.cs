using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    public GameObject bubblePrefab; // Reference to the bubble prefab
    public RectTransform spawnArea; // Area where bubbles can spawn

    public float spawnInterval = 2f; // Time interval between spawns
    private float spawnTimer;
    private bool isSpawning = true;

    void Update()
    {
        if (!isSpawning) return; // Stop updating if spawning is disabled

        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            SpawnBubble();
            spawnTimer = 0f;
        }
    }

    void SpawnBubble()
    {
        // Generate a random position within the spawn area
        Vector2 randomPosition = new Vector2(
            Random.Range(spawnArea.rect.xMin, spawnArea.rect.xMax),
            Random.Range(spawnArea.rect.yMin, spawnArea.rect.yMax)
        );

        // Convert the position to world space
        Vector3 worldPosition = spawnArea.TransformPoint(randomPosition);

        // Instantiate the bubble at the generated position
        GameObject newBubble = Instantiate(bubblePrefab, worldPosition, Quaternion.identity, spawnArea);

        // Optionally, adjust bubble size, color, etc.
    }

    public void StopSpawning()
    {
        isSpawning = false;
    }
}

