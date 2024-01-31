using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        var player = other.GetComponentInParent<PlayerController>();
        if(player != null)
        {
            Destroy(gameObject);
        }
    }
}
