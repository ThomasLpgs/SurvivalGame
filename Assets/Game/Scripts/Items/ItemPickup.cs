using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Player player;
    public GameObject myPrefab;

    private float helperDeadTime = 0.0f;
    private float deadPeriod = 1.0f;
    private float nextActionTimeDead = 1.0f;
    private bool canPickup;

    private void Update()
    {
        if (canPickup)
            return;

        helperDeadTime += Time.deltaTime;
        if (helperDeadTime > nextActionTimeDead)
        {
            nextActionTimeDead += deadPeriod;
            // execute block of code here
            canPickup = true;
        }
    }

    private void Awake()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name != "Player" || !canPickup)
            return;

        player.addHunger(20);
        Destroy(gameObject);
    }

}
