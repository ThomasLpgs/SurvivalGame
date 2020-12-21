using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    static Animator anim;

    public CharacterController controller;

    public float speed = 0f;
    public float walkSpeed = 10f;
    public float sprintSpeed = 15f;
    public float gravity = -29.43f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(isGrounded)
        {
            /*if(Input.GetButtonDown("Jump"))
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }*/
            if(Input.GetButtonDown("Jump"))
            {
                anim.SetTrigger("isjumping");
            }
            if(Input.GetKey(KeyCode.LeftShift) && z == 1)
            {
                speed = sprintSpeed;
                anim.SetBool("isrunning", true);
                if(Input.GetButtonDown("Fire1"))
                {
                    anim.SetTrigger("dropkick");
                }
            }
            else if(z == 1)
            {
                speed = walkSpeed;
                anim.SetBool("iswalking", true);
                anim.SetBool("isidle", false);
                anim.SetBool("isrunning", false);
            }
            else
            {
                anim.SetBool("iswalking", false);
                anim.SetBool("isrunning", false);
                anim.SetBool("isidle", true);

            }
            if(Input.GetButtonDown("Fire1"))
            {
                anim.SetTrigger("lowkick");
            }

        }


        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
