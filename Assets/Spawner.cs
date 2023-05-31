using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField]
    private GameObject skullPrefab;
    [SerializeField]
    private Vector3 spawnAreaSize;
    [SerializeField]
    private float spawnInterval = 2f;
    private float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnSkull(RandomPointInSpawnArea());

            timer = 0f;
        }
    }

    private Vector3 RandomPointInSpawnArea()
    {
        Vector3 randomPoint = transform.position +
        new Vector3(Random.Range(-spawnAreaSize.x / 2f, spawnAreaSize.x / 2f),
                Random.Range(-spawnAreaSize.y / 2f, spawnAreaSize.y / 2f),
                Random.Range(-spawnAreaSize.z / 2f, spawnAreaSize.z / 2f));

        return randomPoint;
    }

    private void SpawnSkull(Vector3 spawnPosition)
    {
        GameObject skull = Instantiate(skullPrefab, spawnPosition, skullPrefab.transform.rotation);

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, spawnAreaSize);
    }
}
