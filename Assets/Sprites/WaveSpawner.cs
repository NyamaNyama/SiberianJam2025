using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class EnemyGroup
{
    public GameObject enemyPrefab;
    public int count;
    public float spawnDelay = 0.5f;
}

[System.Serializable]
public class Wave
{
    public List<EnemyGroup> enemyGroups;
}

public class WaveSpawner : MonoBehaviour
{
    public List<Wave> waves;
    public Transform spawnPoint;
    public WaypointPath[] paths; // несколько путей/линий

    private int currentWave = 0;

    void Start()
    {
        StartCoroutine(SpawnWaveRoutine());
    }

    IEnumerator SpawnWaveRoutine()
    {
        while (currentWave < waves.Count)
        {
            Wave wave = waves[currentWave];

            foreach (EnemyGroup group in wave.enemyGroups)
            {
                for (int i = 0; i < group.count; i++)
                {
                    // ¬ыбираем случайный путь
                    WaypointPath selectedPath = paths[Random.Range(0, paths.Length)];

                    // —мещение по Y дл€ разнообрази€ (можно отключить или уменьшить)
                    Vector3 offset = new Vector3(0, Random.Range(-0.3f, 0.3f), 0);

                    GameObject enemyGO = Instantiate(group.enemyPrefab, spawnPoint.position + offset, Quaternion.identity);
                    Enemy enemy = enemyGO.GetComponent<Enemy>();
                    enemy.Init(selectedPath);

                    yield return new WaitForSeconds(group.spawnDelay);
                }
            }

            currentWave++;
            yield return new WaitForSeconds(2f); // пауза между волнами
        }
    }
}
