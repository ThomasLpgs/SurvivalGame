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
	public float move_speed_attack = 5.0f;
	public float move_speed_walk = 1.0f;
	public float damping = 6.0f;
	//Renderer render;
	private float nextActionTime = 0.0f;
	public int damagePerSecond = 10;
	private float period = 1.0f;
	private float helperAgroTime = 0.0f;
	private float helperIdleTime = 0.0f;
	private float idlePeriod = 5.0f;
	private float nextActionTimeIdle = 0.0f;
	private bool idle = true;
	public int gravity = -29;
	private Vector3 moveDirection = Vector3.zero;
	public CharacterController controller;
	public Transform groundCheck;
	public float groundDistance = 0.0f;
	public LayerMask groundMask;
	private float timeToChangeDirection;

	Vector3 velocity;
	bool isGrounded;

	// Use this for initialization
	void Start()
	{
		//render = GetComponent<Renderer>();
		anim = GetComponent<Animator>();
		ChangeDirection();
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
		}

		if (distancefrom_player < agro_range)
		{
			//render.material.color = Color.red;
			anim.SetBool("isrunning", true);
			Attack();

			if (distancefrom_player < attack_range)
			{
				helperAgroTime += Time.deltaTime;
				if (helperAgroTime > nextActionTime)
				{
					nextActionTime += period;
					// execute block of code here
					player.TakeDamage(damagePerSecond);
				}
			}
			else
			{
				helperAgroTime = 0.0f;
				nextActionTime = 0.0f;
			}

			helperIdleTime = 0.0f;
			nextActionTimeIdle = 0.0f;
		} else
        {
			helperIdleTime += Time.deltaTime;
			if (helperIdleTime > nextActionTimeIdle)
            {
				nextActionTimeIdle += idlePeriod;
				if (idle)
                {
					anim.SetBool("isidle", false);
					anim.SetBool("iswalking", true);
					idle = false;
                } else
                {
					anim.SetBool("isidle", true);
					anim.SetBool("iswalking", false);
					idle = true;
				}
            } else
            {
				if (!idle)
                {
					timeToChangeDirection -= Time.deltaTime;

					if (timeToChangeDirection <= 0)
					{
						ChangeDirection();
					}

					moveDirection = transform.forward;
					moveDirection *= move_speed_walk;

					moveDirection.y += gravity * Time.deltaTime; // doesn't seem to work right :(
					controller.Move(moveDirection * Time.deltaTime);
				}
            }
			/*
			*/
		}

		velocity.y += gravity * Time.deltaTime;

		controller.Move(velocity * Time.deltaTime);
	}

	private void ChangeDirection()
	{
		float angle = Random.Range(0f, 360f);
		Quaternion quat = Quaternion.AngleAxis(angle, new Vector3(0,1,0));
		transform.rotation = Quaternion.Slerp(transform.rotation, quat, Time.deltaTime * damping);
		timeToChangeDirection = 1.5f;
	}

	void LookAt()
	{
		Quaternion rotation = Quaternion.LookRotation(player.transform.position - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
	}

	void Attack()
	{
		moveDirection = transform.forward;
		moveDirection *= move_speed_attack;

		moveDirection.y += gravity * Time.deltaTime; // doesn't seem to work right :(
		controller.Move(moveDirection * Time.deltaTime);
		//transform.Translate(Vector3.forward * move_speed * Time.deltaTime);
	}

	
}
