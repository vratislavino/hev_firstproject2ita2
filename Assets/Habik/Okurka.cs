using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Okurka : FallingObject
{
    public override void Collect() {
        Cholesterol.Instance.AddCholesterol(-10);
    }
}
