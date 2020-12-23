using UnityEngine;
using System.Collections;

public class AIEnemy : MonoBehaviour
{
	private Animator anim;
	public Player player;
	float distancefrom_player;
	public float attack_range = 3.0f;
	public float look_range = 20.0f;
	public float agro_range = 10.0f;
	public float move_speed = 5.0f;
	public float damping = 6.0f;
	//Renderer render;
	private float nextActionTime = 0.0f;
	public int damagePerSecond = 10;
	private float period = 1.0f;
	private float time = 0.0f;
	public int gravity = -29;
	private Vector3 moveDirection = Vector3.zero;
	public CharacterController controller;
	public Transform groundCheck;
	public float groundDistance = 0.0f;
	public LayerMask groundMask;

	Vector3 velocity;
	bool isGrounded;

	// Use this for initialization
	void Start()
	{
		//render = GetComponent<Renderer>();
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

		if (isGrounded && velocity.y < 0)
		{
			velocity.y = -2f;
		}

		distancefrom_player = Vector3.Distance(player.transform.position, transform.position);

		if (distancefrom_player < look_range)
		{
			//transform.LookAt(player);
			//render.material.color = Color.yellow;
			anim.SetBool("isrunning", false);
			LookAt();
		} else
        {
			//render.material.color = Color.green;
			anim.SetBool("isrunning", false);
		}

		if (distancefrom_player < agro_range)
		{
			//render.material.color = Color.red;
			anim.SetBool("isrunning", true);
			Attack();
		}

		if (distancefrom_player < attack_range)
        {
			time += Time.deltaTime;
			if (time > nextActionTime)
			{
				nextActionTime += period;
				// execute block of code here
				player.TakeDamage(damagePerSecond);
			}
        } else
        {
			time = 0.0f;
			nextActionTime = 0.0f;
		}

		velocity.y += gravity * Time.deltaTime;

		controller.Move(velocity * Time.deltaTime);
	}

	void LookAt()
	{
		Quaternion rotation = Quaternion.LookRotation(player.transform.position - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
	}

	void Attack()
	{
		moveDirection = transform.forward;
		moveDirection *= move_speed;

		moveDirection.y += gravity * Time.deltaTime; // doesn't seem to work right :(
		controller.Move(moveDirection * Time.deltaTime);
		//transform.Translate(Vector3.forward * move_speed * Time.deltaTime);
	}

	
}
