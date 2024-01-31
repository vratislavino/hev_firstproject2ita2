using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.name);

        var dmgableObject = collision.collider.GetComponent<IDamagable>();
        Debug.Log(dmgableObject);
        if(dmgableObject != null)
        {
            dmgableObject.ApplyDamage(20);
        }
        Destroy(gameObject);
    }
}
