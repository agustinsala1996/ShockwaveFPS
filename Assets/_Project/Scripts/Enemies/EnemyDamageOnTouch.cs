using UnityEngine;

public class EnemyDamageOnTouch : MonoBehaviour
{
    DamageDealer damageDealer;

    void Awake()
    {
        damageDealer = GetComponent<DamageDealer>();
    }

    void OnTriggerEnter(Collider other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();

        if (damageable == null)
            return;

        damageDealer.DealDamage(damageable);
    }
}