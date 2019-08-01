using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public Enemy[] enemies;
        public int count;
        public float TimeBetweenSpawns;
    }

    public Wave[] waves;
    public Transform[] SpawnPoints;
    public float TimeBetweenWaves;

    private Wave CurrentWave;
    private int CurrentWaveIndex;
    private Transform player;
    private bool FinishedSpawning;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(StartNextWave(CurrentWaveIndex));
        
    }

    IEnumerator StartNextWave(int index)
    {
        yield return new WaitForSeconds(TimeBetweenWaves);
        StartCoroutine(SpawnWave(index));
    }

    IEnumerator SpawnWave(int index)
    {
        CurrentWave = waves[index];
        for (int i = 0; i < CurrentWave.count; i++)
        {
            if (player == null)
            {
                yield break;
            }

            Enemy RandomEnemy = CurrentWave.enemies[Random.Range(0, CurrentWave.enemies.Length)];
            Transform RandomSpot = SpawnPoints[Random.Range(0, SpawnPoints.Length)];
            Instantiate(RandomEnemy, RandomSpot.position, RandomSpot.rotation);

            if (i == CurrentWave.count - 1)
            {
                FinishedSpawning = true;
            }
            else
            {
                FinishedSpawning = false;
            }
            yield return new WaitForSeconds(CurrentWave.TimeBetweenSpawns);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (FinishedSpawning == true && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            FinishedSpawning = false;
            if (CurrentWaveIndex + 1 < waves.Length)
            {
                CurrentWaveIndex++;
                StartCoroutine(StartNextWave(CurrentWaveIndex));
            }
            else
            {
                Debug.Log("Game Finished");
            }
        }
    }
}
