using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public int ammoAmount = 10;

    private void OnTriggerEnter(Collider other)
    {
        WeaponHandler weaponHandler = other.GetComponent<WeaponHandler>();

        if (weaponHandler == null)
            return;

        weaponHandler.AddAmmo(ammoAmount);
        Destroy(gameObject);
    }
}