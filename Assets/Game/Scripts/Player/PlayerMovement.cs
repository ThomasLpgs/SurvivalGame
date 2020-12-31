using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    static Animator anim;
    public Player player;
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
            if(Input.GetButtonDown("Jump"))
            {
                if(player.currentStamina > 20 && player.currentHunger > 0)
                {
                    //anim.SetTrigger("isjumping");
                    player.usingStamina(20);
                    player.Hungry(4); 
                    velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                }
            }
            if(Input.GetKey(KeyCode.LeftShift) && z == 1)
            {
                if(player.currentStamina > 0 && player.currentHunger > 0)
                {
                    speed = sprintSpeed;
                    anim.SetBool("isrunning", true);
                    if(Input.GetButtonDown("Fire1"))
                    {
                        anim.SetTrigger("dropkick");
                    }
                    player.usingStamina(Time.deltaTime * 10);
                    player.Hungry(Time.deltaTime * 2);
                }
                else
                {
                    speed = walkSpeed;
                    anim.SetBool("iswalking", true);
                    anim.SetBool("isidle", false);
                    anim.SetBool("isrunning", false);
                    if (player.currentStamina < player.maxStamina)
                    {
                        player.addStamina(Time.deltaTime * 10);
                    }
                    player.Hungry(Time.deltaTime);
                }
            }
            else if(z == 1)
            {
                speed = walkSpeed;
                anim.SetBool("iswalking", true);
                anim.SetBool("isidle", false);
                anim.SetBool("isrunning", false);
                if (player.currentStamina < player.maxStamina)
                {
                    player.addStamina(Time.deltaTime * 10);
                }
                player.Hungry(Time.deltaTime);
            }
            else
            {
                anim.SetBool("iswalking", false);
                anim.SetBool("isrunning", false);
                anim.SetBool("isidle", true);
                if (player.currentStamina < player.maxStamina)
                {
                    player.addStamina(Time.deltaTime * 20);
                }
            }
            if(Input.GetButtonDown("Fire1"))
            {
                anim.SetTrigger("lowkick");
            
            }
            /*if(player.currentHunger == 0)
            {
                player.TakeDamage(Time.deltaTime * 5);
            }
            else if(player.currentHunger == 100)
            {
                player.Heal(Time.deltaTime * 8);
            }*/
        }

        


        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
