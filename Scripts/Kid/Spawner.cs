using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

   [SerializeField] public GameObject[] spawners = new GameObject[6];
    public GameObject zombie;   

    private int enemyCount;
    private int waveNumber = 1;
 
    public float timeBetweenEnemySpawn = 2f;
    public float timeBetweenWaves = 5f;
    bool spawningWave;




    void Start()
    {
        spawningWave = false;
        StartCoroutine(SpawnEnemyWave(waveNumber));

    }

    // Update is called once per frame
    void Update()
    {
       enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
 
        if (enemyCount == 0 && !spawningWave)
        {
            waveNumber++;
            StartCoroutine(SpawnEnemyWave(waveNumber));
        }
       
        
    }
    
    IEnumerator SpawnEnemyWave(int enemiesToSpawn)
    {
        spawningWave = true;
        yield return new WaitForSeconds(timeBetweenWaves); //We wait here to pause between wave spawning
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(zombie, spawners[Random.Range(0,5)].transform.position, transform.rotation);
            yield return new WaitForSeconds(timeBetweenEnemySpawn); //We wait here to give a bit of time between each enemy spawn
        }
        spawningWave = false;
    }
    
}
