using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public event Action<bool> IsPossibleToAttackChanged;

    public Func<string, bool> ControlPress;

    protected void RaiseIsPossibleToAttackChanged(bool isPossibleToAttack)
    {
        IsPossibleToAttackChanged?.Invoke(isPossibleToAttack);
    }

    protected virtual void Start()
    {
        
    }

    public abstract void Attack();
}
