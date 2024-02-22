using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RangedEnemy : BaseEnemy
{
    [SerializeField] float shootInterval = 2f;
    float shootCooldown;

    [SerializeField] Bullet bulletPrefab;
    [SerializeField] Transform shootPoint;


    protected override void Start()
    {
        base.Start();
        shootCooldown = shootInterval;
    }

    private void Update()
    {
        transform.LookAt(player.transform.position + Vector3.up);
        if(shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
            if(shootCooldown <= 0)
            {
                Shoot();
                shootCooldown = shootInterval;
            }
        }
    }

    private void Shoot()
    {
        var b = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        var rb = b.GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.AddForce(b.transform.forward * 20, ForceMode.Impulse);
    }
}
