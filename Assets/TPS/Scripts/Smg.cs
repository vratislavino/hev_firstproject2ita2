using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smg : RangedWeapon
{
    protected override void Start()
    {
        base.Start();
        ControlPress = Input.GetButton;
    }
}
