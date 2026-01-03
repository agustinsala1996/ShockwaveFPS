    using UnityEngine;

    public class HitscanWeapon : WeaponBase
    {
        [Header("Hitscan")]
        [SerializeField] float range = 100f;
        [SerializeField] LayerMask hitMask;

        public override void Fire()
        {
            Camera cam = Camera.main;
            if (!cam) return;

            Ray ray = new Ray(cam.transform.position, cam.transform.forward);

            if (Physics.Raycast(ray, out RaycastHit hit, range, hitMask))
            {
                Debug.Log("Hit: " + hit.collider.name);
            }
        }
    }