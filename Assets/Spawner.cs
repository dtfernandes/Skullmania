using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameLoopManager _gameLoop;
    [SerializeField]
    private Skull skullPrefab;
    [SerializeField]
    private Vector3 spawnAreaSize;
    [SerializeField]
    private float spawnInterval = 2f;
    private float timer = 0f;
    private bool _paused;

    private List<Skull> skullList;

    private void Start()
    {
        skullList = new List<Skull>(); 
        _gameLoop.OnEndGame.AddListener(EndSpawn);
        _gameLoop.OnRestart.AddListener(StartSpawn);
    }
    private void Update()
    {
        if (_paused)
            return;
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnSkull(RandomPointInSpawnArea());

            timer = 0f;
        }
    }

    public void StartSpawn()
    {
        _paused = false;
    }
    public void EndSpawn()
    {
        _paused = true;
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
        Skull skull = Instantiate(skullPrefab, spawnPosition, skullPrefab.transform.rotation);
        skull.onDie += () => { skullList.Remove(skull); };
        skullList.Add(skull);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, spawnAreaSize);
    }

    public void Stop()
    {
        _paused = true;
        foreach(Skull g in skullList)
        {
            Destroy(g.gameObject);
        }
    }
}
