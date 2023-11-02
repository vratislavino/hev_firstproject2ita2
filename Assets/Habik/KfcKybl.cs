using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KfcKybl : FallingObject
{
    public override void Collect() {
        Cholesterol.Instance.AddCholesterol(3);
    }
}
