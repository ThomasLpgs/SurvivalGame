using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationPlayerController : MonoBehaviour
{

    static Animator anim;
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            anim.SetTrigger("isjumping");
        }
    }
}
