using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : BaseEnemy
{
    [SerializeField] float speed = 2f;
    Rigidbody rb;

    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.LookAt(player.transform.position + Vector3.up);
        var move = transform.forward;
        move.y = 0;
        rb.velocity = move * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject == player.gameObject)
        {
            player.ApplyDamage(1);
        }
    }
}
