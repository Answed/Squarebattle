using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] enemy;
    public GameObject[] spawnPoints;
    public TextMeshProUGUI waveScore;
    private GameObject[] enemiesAlive;
    private Shop score;
    public int waveNumber;
    private PlayerDamage playerDm;
    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Shop>();
        playerDm = GameObject.Find("Player").GetComponentInChildren<PlayerDamage>();
        waveScore.text = ("Wave: " + waveNumber);
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        enemiesAlive = GameObject.FindGameObjectsWithTag("Enemy");


        if (enemiesAlive.Length == 0 && player.gameIsActive == true)
        {
            waveNumber++;
            waveScore.text = ("Wave: " + waveNumber);
            score.UpdateScore(waveNumber);
            if (waveNumber < 10)
            {
                for (int i = 0; i <= waveNumber; i++)
                {
                    Instantiate(enemy[0], RandomSpawnPosition(), enemy[0].transform.rotation);
                }
            }
            else if (waveNumber >= 10 && waveNumber < 20)
            {
                for (int i = 0; i <= waveNumber; i++)
                {
                    int randEnemey = Random.Range(0, 2);
                    Debug.Log(randEnemey);
                    Instantiate(enemy[randEnemey], RandomSpawnPosition(), enemy[randEnemey].transform.rotation);
                }
            }
            else if (waveNumber >= 20)
            {
                for (int i = 0; i <= waveNumber; i++)
                {
                    int randEnemey = Random.Range(0, 3);
                    Instantiate(enemy[randEnemey], RandomSpawnPosition(), enemy[randEnemey].transform.rotation);
                }
            }else if (player.gameIsActive == false)
            {
                int i = 0;
                do
                {
                    Destroy(enemiesAlive[i]);
                    i++;
                }
                while (enemiesAlive.Length > 0);
            }
        }
    }

    public Vector3 RandomSpawnPosition()
    {
        int randPos = Random.Range(0, spawnPoints.Length);
        Vector3 spawnPosition;

        if (randPos >= 2)
        {
            spawnPosition = new Vector3(spawnPoints[randPos].transform.position.x, spawnPoints[randPos].transform.position.y + Random.Range(-20, 20), 0);
        }else
        {
            spawnPosition = new Vector3(spawnPoints[randPos].transform.position.x + Random.Range(-30, 30), spawnPoints[randPos].transform.position.y, 0);
        }
        return spawnPosition;
    }
}
