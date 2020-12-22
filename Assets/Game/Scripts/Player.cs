using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	//Setting Health, Hunger and Stamina
	public int maxHealth = 100;
	public int currentHealth;
	public HealthBar healthBar;

	public int maxHunger = 100;
	public int currentHunger;
	public HungerBar hungerBar;

	public int maxStamina = 100;
	public int currentStamina;
	public StaminaBar staminaBar;

    // Start is called before the first frame update
    void Start()
    {
		//Initialise HP, Food and Stamina
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);

		currentHunger = maxHunger;
		hungerBar.SetMaxHunger(maxHunger);

		currentStamina = maxStamina;
		staminaBar.SetMaxStamina(maxStamina);
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Space))
		{
			usingStamina(20);
		}
    }

	public void TakeDamage(int p_damage)
	{
		currentHealth -= p_damage;

		healthBar.SetHealth(currentHealth);
	}

	void Hungry(int p_hunger)
	{
		currentHunger -= p_hunger;

		hungerBar.SetHunger(currentHunger);
	}

	void usingStamina(int p_staminaUsed)
	{
		currentStamina -= p_staminaUsed;

		staminaBar.SetStamina(currentStamina);
	}


}
