using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    [Header("Weapon Stats")]
    public float damage = 10f;
    public float fireRate = 0.2f;
    public int maxAmmo = 30;

    protected int currentAmmo;
    protected float lastFireTime;

    protected virtual void Awake()
    {
        currentAmmo = maxAmmo;
    }

    public virtual bool CanFire()
    {
        return Time.time >= lastFireTime + fireRate && currentAmmo > 0;
    }

    public virtual void TryFire()
    {
        if (!CanFire())
            return;

        Fire();
        currentAmmo--;
        lastFireTime = Time.time;
    }

    public virtual void Fire()
    {
    }
}