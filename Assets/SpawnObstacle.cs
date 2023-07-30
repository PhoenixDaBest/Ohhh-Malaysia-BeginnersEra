using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    public GameObject objectPrefab;
    public float spawnInterval = 1.5f; // Adjust this value to control the spawn interval
    public float spawnAreaWidth = 5f; // Adjust this value to control the spawn area width

    private float timer;

    private bool start = false;

    void Start()
    {
        StartCoroutine(StartDelay());
    }

    void Update()
    {
        if (start)
        {
            // Count down the timer
            timer -= Time.deltaTime;

            // Check if it's time to spawn a new object
            if (timer <= 0f)
            {
                SpawnObject();
                timer = spawnInterval;
            }
        }
    }

    void SpawnObject()
    {
        // Randomly choose the offset within the spawn area width
        float spawnOffsetX = Random.Range(-spawnAreaWidth / 2f, spawnAreaWidth / 2f);

        // Calculate the spawn position relative to the GameObject's position
        Vector3 spawnPosition = transform.position + new Vector3(spawnOffsetX, 0f, 0f);

        // Instantiate the object at the spawn position
        Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
    }

    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(5);
        start = true;
    }
}
