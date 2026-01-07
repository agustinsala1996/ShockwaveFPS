using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public float healAmount = 25f;

    void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        if (playerHealth == null)
            return;

        playerHealth.Heal(healAmount);
        Destroy(gameObject);
    }
}