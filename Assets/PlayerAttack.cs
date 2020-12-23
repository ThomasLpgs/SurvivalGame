using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int lowKickDamage = 10;
    public int dropKickDamage = 50;
    public int maxDistance = 2;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (anim.GetBool("lowkick"))
        {
            //Debug.Log("attack");

            Collider[] hitColliders = Physics.OverlapSphere(transform.parent.position, maxDistance);
            //Debug.Log("colliders:" + hitColliders.Length);
            foreach (var hitCollider in hitColliders)
            {
                //Debug.Log("name:" + hitCollider.name);
                hitCollider.SendMessage("ApplyDamage", lowKickDamage, SendMessageOptions.DontRequireReceiver); 
            }
        } else if (anim.GetBool("dropkick"))
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.parent.position, maxDistance);
            //Debug.Log("colliders:" + hitColliders.Length);
            foreach (var hitCollider in hitColliders)
            {
                //Debug.Log("name:" + hitCollider.name);
                hitCollider.SendMessage("ApplyDamage", dropKickDamage, SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}