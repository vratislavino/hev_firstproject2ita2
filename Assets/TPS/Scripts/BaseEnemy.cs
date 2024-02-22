using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour, IDamagable
{
    protected PlayerController player;
    bool isDying = false;

    [SerializeField]
    protected int MaxHp = 100;

    public int HP { get; set; }

    public void ApplyDamage(float dmg)
    {
        HP -= (int)dmg;
        if (HP <= 0) Die();
    }

    protected void Die()
    {
        if (isDying) return;
        isDying = true;

        FindObjectOfType<ScoreChanger>().AddScore();
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        player = FindObjectOfType<PlayerController>();
        HP = MaxHp;
    }
}
