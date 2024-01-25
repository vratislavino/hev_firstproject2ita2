using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : RangedWeapon
{
    [SerializeField]
    private int bulletCount = 5;

    [SerializeField]
    private float spread = 5;

    protected override void Shoot()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            var bullet = Instantiate(bulletPrefab, shootPoint.position, transform.rotation);
            bullet.transform.Rotate(Random.Range(-spread, spread), Random.Range(-spread, spread), 0,Space.Self);
            bullet.AddForce(bullet.transform.forward * 100, ForceMode.Impulse);
            Destroy(bullet.gameObject, 4f);
        }
    }
}
