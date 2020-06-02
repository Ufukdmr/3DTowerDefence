using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform[] enemyPrefabs;
    public Transform[] spanwPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    private int waveIndex = 0;

    void Update()
    {
        if (countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;
    }
    IEnumerator SpawnWave()
    {
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        
    }
    void SpawnEnemy()
    {
        Instantiate(enemyPrefabs[Random.Range(0, 4)], spanwPoint[0].position, spanwPoint[0].rotation);
    }
}
