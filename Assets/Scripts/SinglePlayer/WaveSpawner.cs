using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public Enemy[] enemies; //array contains all the different type of enemies that can spawn in a wave
        public int count; //dictates how many enemies can spawn in a wave
        public float timeBetweenSpawns; //dictates the time between each spawn
    }

    public Wave[] waves;
    public Transform[] spawnPoints; //contains the points where enemies can spawn from
    public float timeBetweenWaves;

    private Wave currentWave; //stores current wave
    private int currentWaveIndex;
    private int prevWaveIndex = -1;
    public Transform player; //reference to the player

    public int count = 1;
    private bool finishedSpawning;

    public GameObject boss;
    public Transform bossSpawnPoint;

    public GameObject healthBar;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(StartNextWave(currentWaveIndex));
    }

    IEnumerator StartNextWave(int index)
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            yield return new WaitForSeconds(1);
        }
        else
        {
            yield return new WaitForSeconds(timeBetweenWaves);
        }
        StartCoroutine(SpawnWave(index));
    }

    IEnumerator SpawnWave(int index)
    {
        currentWave = waves[index];

        if (index == prevWaveIndex) {
            currentWave.count = currentWave.count + 5;
        }

        for (int i = 0; i < currentWave.count; i++)
        {
            if (player == null)
            {
                yield break;
            }

            Enemy randomEnemy = currentWave.enemies[Random.Range(0, currentWave.enemies.Length)];
            Transform randomSpot = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(randomEnemy, randomSpot.position, randomSpot.rotation);

            if (i == currentWave.count - 1)
            {
                finishedSpawning = true;
            }
            else
            {
                finishedSpawning = false;
            }

            yield return new WaitForSeconds(currentWave.timeBetweenSpawns);
        }
    }

    void Update()
    {
        if (finishedSpawning == true)// && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                finishedSpawning = false;
                if (currentWaveIndex + 1 < waves.Length)
                {
                    count++;
                    timeBetweenWaves = timeBetweenWaves + 5;
                    prevWaveIndex = currentWaveIndex;
                    currentWaveIndex++;
                    StartCoroutine(StartNextWave(currentWaveIndex));
                }
                else
                {
                if (count % 4 == 0)
                {
                    if (GameObject.FindGameObjectsWithTag("Boss").Length == 0)
                    {
                        Instantiate(boss, bossSpawnPoint.position, bossSpawnPoint.rotation);
                        healthBar.SetActive(true);
                    }
                }
                    prevWaveIndex = currentWaveIndex;
                    StartCoroutine(StartNextWave(currentWaveIndex));

                }
            }
    }
}


