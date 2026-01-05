using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    //Stats del arma
    public float fireRate = 0.2f;
    public int maxAmmo = 30;

    protected int currentAmmo;
    protected float lastFireTime;

    protected virtual void Awake()
    {
        currentAmmo = maxAmmo;
    }

    public bool CanFire()
    {
        return Time.time >= lastFireTime + fireRate && currentAmmo > 0;
    }

    public virtual void TryFire()
    {
        if (!CanFire())
        {
            if (currentAmmo <= 0)
                OnEmptyFire();

            return;
        }

        Fire();
        currentAmmo--;
        lastFireTime = Time.time;
    }

    protected abstract void Fire();

    protected virtual void OnEmptyFire()
    {
        Debug.Log("Click! Sin munición");
    }
}