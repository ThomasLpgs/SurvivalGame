using UnityEngine;

public class Player : MonoBehaviour
{
	//Setting Health, Hunger and Stamina
	public int maxHealth = 100;
	public float currentHealth;
	public HealthBar healthBar;

	public int maxHunger = 100;
	public float currentHunger;
	public HungerBar hungerBar;

	public int maxStamina = 100;
	public float currentStamina;
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
		
    }

	public void TakeDamage(float p_damage)
	{
		currentHealth -= p_damage;

		healthBar.SetHealth(currentHealth);
	}

	public void Heal(float p_heal)
	{
		currentHealth += p_heal;

		healthBar.SetHealth(currentHealth);
	}

	public void Hungry(float p_hunger)
	{
		currentHunger -= p_hunger;

		hungerBar.SetHunger(currentHunger);
	}

	public void Eat(float p_eat)
	{
		currentHunger += p_eat;

		hungerBar.SetHunger(currentHunger);
	}

	public void usingStamina(float p_staminaUsed)
	{
		currentStamina -= p_staminaUsed;

		staminaBar.SetStamina(currentStamina);
	}

	public void addStamina(float p_addstamina)
	{
		currentStamina += p_addstamina;

		staminaBar.SetStamina(currentStamina);
	}

    public void addHunger(float p_addHunger)
    {
        if (currentHunger + p_addHunger >= 100)
            currentHunger = 100;
        else
            currentHunger += p_addHunger;

		hungerBar.SetHunger(currentHunger);
    }

}
