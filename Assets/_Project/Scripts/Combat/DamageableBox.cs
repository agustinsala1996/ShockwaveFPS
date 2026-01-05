using UnityEngine;

public class DamageableBox : MonoBehaviour, IDamageable
{
    public float health = 20f;

    public void TakeDamage(float amount)
    {
        health -= amount;
        Debug.Log("Caja dañada. HP: " + health);

        if (health <= 0f)
        {
            Destroy(gameObject);
        }
    }
}