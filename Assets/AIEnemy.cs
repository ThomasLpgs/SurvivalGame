using UnityEngine;
using System.Collections;

public class AIEnemy : MonoBehaviour
{
	public Player player;
	float distancefrom_player;
	public float attack_range = 3.0f;
	public float look_range = 20.0f;
	public float agro_range = 10.0f;
	public float move_speed = 5.0f;
	public float damping = 6.0f;
	Renderer render;
	private float nextActionTime = 0.0f;
	public int damagePerSecond = 10;
	private float period = 1.0f;
	private float time = 0.0f;
	// Use this for initialization
	void Start()
	{
		render = GetComponent<Renderer>();
	}

	// Update is called once per frame
	void Update()
	{
		distancefrom_player = Vector3.Distance(player.transform.position, transform.position);

		if (distancefrom_player < look_range)
		{
			//transform.LookAt(player);
			render.material.color = Color.yellow;
			lookAt();
		} else
        {
			render.material.color = Color.green;
        }

		if (distancefrom_player < agro_range)
		{
			render.material.color = Color.red;
			attack();
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
	}

	void lookAt()
	{
		Quaternion rotation = Quaternion.LookRotation(player.transform.position - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
	}

	void attack()
	{
		transform.Translate(Vector3.forward * move_speed * Time.deltaTime);
	}
}
