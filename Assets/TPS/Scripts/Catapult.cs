using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catapult : MonoBehaviour
{
    [SerializeField]
    private float force = 100;
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponentInParent<PlayerController>();
        if (player != null)
        {
            player.Rb.AddForce(Vector3.up * force, ForceMode.Impulse);
        }
    }
}
