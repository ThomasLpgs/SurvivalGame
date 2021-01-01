using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    public GameObject meat;
    public int health = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*
    public void ApplyDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            StartCoroutine(ApplyDamageCoroutine());
            //EnemiesSpawn.enemyCount -= 1;
        }
    }

    IEnumerator ApplyDamageCoroutine()
    {
        Vector3 posWolf = gameObject.transform.position;
        var newMeat = Instantiate(meat, posWolf, Quaternion.identity);
        gameObject.SetActive(false);
        yield return new WaitForSeconds(1);
        newMeat.SetActive(true);
        Destroy(gameObject);
    }
    */
}
