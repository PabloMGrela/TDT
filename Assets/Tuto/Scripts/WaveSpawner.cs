﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5.5f;
    private float countdown = 3f;
    private int waveNumber = 0;
    public Text waveCountdownText;


    void Update()
    {
            if(countdown <= 0f){
                StartCoroutine(SpawnWave());
                countdown = timeBetweenWaves;
            }

            countdown -= Time.deltaTime;
            waveCountdownText.text = Mathf.Round(countdown).ToString();
    }

    IEnumerator SpawnWave(){
        waveNumber++;

        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemy(){
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
