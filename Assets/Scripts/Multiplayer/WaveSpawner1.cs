using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class WaveSpawner1 : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public GameObject[] enemies; //array contains all the different type of enemies that can spawn in a wave
        public int count; //dictates how many enemies can spawn in a wave
        public float timeBetweenSpawns; //dictates the time between each spawn
    }

    public Wave[] waves;
    public Transform[] spawnPoints; //contains the points where enemies can spawn from
    public float timeBetweenWaves;

    private Wave currentWave; //stores current wave
    private int currentWaveIndex;
    private int prevWaveIndex = -1;
    public GameObject[] players;//reference to the player


    private bool finishedSpawning;
    PhotonView view;
    public GameObject boss;
    public Transform bossSpawnPoint;

    public GameObject healthBar;

    void Start()
    {
        //numofplayers = GameObject.FindGameObjectsWithTag("Player").Length;
        view = GetComponent<PhotonView>();
        StartCoroutine(StartNextWave(currentWaveIndex));
        //StartCoroutine(view.RPC("StartNextWave", RpcTarget.All, currentWaveIndex));
    }

    
    IEnumerator StartNextWave(int index)
    {
        if (prevWaveIndex != index)
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
        if (view.IsMine)
        {
            currentWave = waves[index];

            if (index == prevWaveIndex)
            {
                currentWave.count++;
            }

            for (int i = 0; i < currentWave.count; i++)
            {
                if (currentWaveIndex==0)
                {
                    players = GameObject.FindGameObjectsWithTag("Player");
                }
                
             //   if (players.Length <= 0)
                //{
              //      yield break;
              //  }

                    GameObject randomEnemy = currentWave.enemies[Random.Range(0, currentWave.enemies.Length)];
                    Transform randomSpot = spawnPoints[Random.Range(0, spawnPoints.Length)];
                    PhotonNetwork.Instantiate(randomEnemy.name, randomSpot.position, randomSpot.rotation);
                
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
    }

    void Update()
    {
        

 
        if (finishedSpawning == true && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            players = GameObject.FindGameObjectsWithTag("Player");
            finishedSpawning = false;
            if (currentWaveIndex + 1 < waves.Length)
            {
                prevWaveIndex = currentWaveIndex;
                currentWaveIndex++;
                StartCoroutine(StartNextWave(currentWaveIndex));
                //StartCoroutine(view.RPC("StartNextWave", RpcTarget.All, currentWaveIndex));
            }
            else
            {
                if (GameObject.FindGameObjectsWithTag("Boss").Length == 0)
                {

                    PhotonNetwork.Instantiate(boss.name, bossSpawnPoint.position, bossSpawnPoint.rotation);
                    view.RPC("health", RpcTarget.All);
                }
                //healthBar.SetActive(true);
                prevWaveIndex = currentWaveIndex;
                StartCoroutine(StartNextWave(currentWaveIndex));
             //   StartCoroutine(view.RPC("StartNextWave", RpcTarget.All, currentWaveIndex));
            }
        }
    }

    [PunRPC] 
    public void health()
    {
        healthBar.SetActive(true);
    }
}


