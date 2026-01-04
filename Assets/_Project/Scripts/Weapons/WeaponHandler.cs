using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    WeaponBase currentWeapon;

    void Awake()
    {
        currentWeapon = GetComponentInChildren<WeaponBase>();
    }

    public void FirePrimary()
    {
        if (currentWeapon == null)
            return;

        currentWeapon.TryFire();
    }
}