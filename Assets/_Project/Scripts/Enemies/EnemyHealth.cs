using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    public float maxHealth = 30f;

    float currentHealth;

    Renderer enemyRenderer;
    Color originalColor;

    void Awake()
    {
        currentHealth = maxHealth;

        enemyRenderer = GetComponentInChildren<Renderer>();
        if (enemyRenderer != null)
            originalColor = enemyRenderer.material.color;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        FlashDamage();

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    void FlashDamage()
    {
        if (enemyRenderer == null)
            return;

        enemyRenderer.material.color = Color.red;
        Invoke(nameof(ResetColor), 0.1f);
    }

    void ResetColor()
    {
        enemyRenderer.material.color = originalColor;
    }

    void Die()
    {
        Debug.Log("Murió");
        Destroy(gameObject);
    }
}