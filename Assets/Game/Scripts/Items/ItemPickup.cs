using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Player player;
    public GameObject myPrefab;

    private void Awake()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        player.addHunger(20);
        Destroy(gameObject);
    }

}
