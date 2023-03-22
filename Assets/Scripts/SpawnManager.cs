using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public GameObject[] powerupPrefab;
    public GameObject boss;
    public GameObject restartPanel;
    private float range = 9;
    private int wave = 1;

    void Start()
    {
        Time.timeScale = 1;
        spawnEnemyWave(wave);
    }

    void Update()
    {
        int enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            if((wave % 5)  != 0)
                spawnEnemyWave(wave);
            else
                spawnBossWave();
        }
    }

    Vector3 GenerateSpawnPosition()
    {
        float xPos = Random.Range(-range, range);
        float zPos = Random.Range(-range, range);
        return new Vector3(xPos, 0, zPos);
    }

    void spawnEnemyWave(int enemyCount)
    {
        for (int i = 0; i < enemyCount; i++)
        {
            int num = Random.Range(0, enemyPrefab.Length);
            Instantiate(enemyPrefab[num], GenerateSpawnPosition(), enemyPrefab[num].transform.rotation);
        }
        int id = Random.Range(0, powerupPrefab.Length);
        Instantiate(powerupPrefab[id], GenerateSpawnPosition(), powerupPrefab[id].transform.rotation);
        wave++;
    }

    void spawnBossWave()
    {
        int num = wave / 5;
        for(int i = 0; i < num; i++)
            Instantiate(boss, GenerateSpawnPosition(), boss.transform.rotation);
        spawnEnemyWave(wave);
    }

    public void EndGame()
    {
        restartPanel.SetActive(true);
        Time.timeScale = 0.0f;
    }
}
