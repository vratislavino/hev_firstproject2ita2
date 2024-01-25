using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RangedWeapon : Weapon
{
    [SerializeField]
    protected float reloadTime;
    private float currentReloadTime;

    public bool IsReloading => currentReloadTime > 0;

    [SerializeField]
    protected float damage;

    [SerializeField]
    protected int maxAmmo;
    private int currentAmmo;

    [SerializeField]
    protected float fireRate;
    private float currentBulletCooldown;

    [SerializeField]
    protected Transform shootPoint;

    [SerializeField]
    protected Rigidbody bulletPrefab;

    protected override void Start()
    {
        base.Start();
        currentAmmo = maxAmmo;
        ControlPress = Input.GetButtonDown;
    }

    private void Update()
    {
        if(Input.GetButtonDown("Reload"))
        {
            currentReloadTime = reloadTime;
            RaiseIsPossibleToAttackChanged(false);
        }
        
        if(currentReloadTime > 0)
        {
            currentReloadTime -= Time.deltaTime;
            if(currentReloadTime <= 0)
            {
                currentAmmo = maxAmmo;
                RaiseIsPossibleToAttackChanged(true);
            }
        }


        if (currentBulletCooldown > 0)
            currentBulletCooldown -= Time.deltaTime;
    }

    public override void Attack()
    {
        if (currentAmmo > 0 && currentBulletCooldown <= 0 && !IsReloading) {
            Shoot();
            currentBulletCooldown = fireRate;
            currentAmmo--;
        }
    }

    protected virtual void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, shootPoint.position, transform.rotation);
        bullet.AddForce(transform.forward * 100, ForceMode.Impulse);
        Destroy(bullet.gameObject, 4f);
    }
}
