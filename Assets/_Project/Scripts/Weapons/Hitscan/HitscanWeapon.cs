using UnityEngine;

public class HitscanWeapon : WeaponBase
{
    public float range = 100f;
    public GameObject hitMarkerPrefab;

    Camera playerCamera;

    protected override void Awake()
    {
        base.Awake();
        playerCamera = Camera.main;
    }

    protected override void Fire()
    {
        Ray ray = new Ray(
            playerCamera.transform.position,
            playerCamera.transform.forward
        );

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, range))
        {
            Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red, 1f);
            Debug.Log("Hit: " + hit.collider.name);

            if (hitMarkerPrefab != null)
            {
                Instantiate(
                    hitMarkerPrefab,
                    hit.point,
                    Quaternion.LookRotation(hit.normal)
                );
            }
        }
        else
        {
            Debug.DrawRay(ray.origin, ray.direction * range, Color.yellow, 1f);
        }
    }
}