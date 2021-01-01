using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawn : MonoBehaviour
{

    public GameObject enemy;
    public int minxPos = 552;
    public int maxxPos = 583;
    public int minzPos = 37;
    public int maxzPos = 53;
    public int yPos = 52;
    public int nbOfEnemies = 10;
    public float timeToWaitBetweenEachEnemyCreation = 1f;
    public int enemyCount = 0;

    private float helperTime = 0.0f;
    private float period = 1.0f;
    private float nextActionTime = 0.0f;

    void Update()
    {
        if (enemyCount < nbOfEnemies)
        {
            helperTime += Time.deltaTime;
            if (helperTime > nextActionTime)
            {
                nextActionTime += period;
                // execute block of code here
                var xPos = Random.Range(minxPos, maxxPos);
                var zPos = Random.Range(minzPos, maxzPos);
                var wolf = Instantiate(enemy, new Vector3(xPos, yPos, zPos), Quaternion.identity);
                wolf.SetActive(true);
                enemyCount += 1;
            }
        }
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount < nbOfEnemies)
        {
            var xPos = Random.Range(minxPos, maxxPos);
            var zPos = Random.Range(minzPos, maxzPos);
            var wolf = Instantiate(enemy, new Vector3(xPos, yPos, zPos), Quaternion.identity);
            wolf.SetActive(true);
            yield return new WaitForSeconds(timeToWaitBetweenEachEnemyCreation);
            enemyCount += 1;
        }
    }

}
