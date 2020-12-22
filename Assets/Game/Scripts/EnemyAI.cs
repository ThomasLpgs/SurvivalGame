using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyAI : MonoBehaviour
{
    public float lookRadius = 10f;
    Transform target;
    NavMeshAgent agent;

    void Start()
    {
        //GameObject.FindGameObject
        agent = GetComponent<NavMeshAgent>();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
        //Gizmos.color = Color.yellow;
        //Gizmos.DawWireSphere(transform.position, sightRange);
    }
}
