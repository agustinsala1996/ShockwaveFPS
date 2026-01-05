using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public float damage = 10f;

    public void DealDamage(IDamageable target)
    {
        target.TakeDamage(damage);
    }
}