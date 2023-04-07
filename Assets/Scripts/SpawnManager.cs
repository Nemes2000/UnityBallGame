using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public GameObject[] powerupPrefab;
    public GameObject boss;
    public GameObject restartPanel;
    public GameObject scoreNumber;
    public GameObject abilityText;
    private float range = 9;
    private int wave = 1;

    void Start()
    {
        Time.timeScale = 1;
        SpawnEnemyWave(wave);
    }

    void Update()
    {
        int enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            if((wave % 5)  != 0)
                SpawnEnemyWave(wave);
            else
                SpawnBossWave();
        }
    }

    Vector3 GenerateSpawnPosition()
    {
        float xPos = Random.Range(-range, range);
        float zPos = Random.Range(-range, range);
        return new Vector3(xPos, 0, zPos);
    }

    void SpawnEnemyWave(int enemyCount)
    {
        for (int i = 0; i < enemyCount; i++)
        {
            int num = Random.Range(0, enemyPrefab.Length);
            Instantiate(enemyPrefab[num], GenerateSpawnPosition(), enemyPrefab[num].transform.rotation);
        }
        int id = Random.Range(0, powerupPrefab.Length);
        Instantiate(powerupPrefab[id], GenerateSpawnPosition(), powerupPrefab[id].transform.rotation);
        SetPlayPanel();
        wave++;
    }

    private void SpawnBossWave()
    {
        int num = wave / 5;
        for(int i = 0; i < num; i++)
            Instantiate(boss, GenerateSpawnPosition(), boss.transform.rotation);
        SpawnEnemyWave(wave);
    }

    public void EndGame()
    {
        restartPanel.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void SetPlayPanel()
    {
        scoreNumber.GetComponent<Text>().text = wave.ToString();
    }

    public void EnableAbilityText(string text)
    {
        abilityText.GetComponent<Text>().text = text;
    }

    public void DisableAbilityText()
    {
        abilityText.GetComponent<Text>().text = "";
    }

}
