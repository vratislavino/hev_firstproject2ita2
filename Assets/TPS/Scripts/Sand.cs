using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sand : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponentInParent<PlayerController>();
        if (player != null)
        {
            player.ChangeEnvSpeedMultiplier(0.5f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var player = other.GetComponentInParent<PlayerController>();
        if (player != null)
        {
            player.ChangeEnvSpeedMultiplier(1f);
        }
    }
}
