using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour, IDamagable
{
    [SerializeField]
    private int MaxHp;

    private int hp;
    public int HP {
        get => hp;
        set => hp = value; 
    }

    public void ApplyDamage(float dmg)
    {
        HP -= (int)dmg;
        if (HP <= 0) Destroy(gameObject);
    }

    void Start()
    {
        HP = MaxHp;   
    }
}
