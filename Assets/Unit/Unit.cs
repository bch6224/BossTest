using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IDamageable
{
    public void TakeDamage(int damage);
}

[System.Serializable]
public struct UnitStat
{
    public int maxHp;
    public int attackPower;
}

public enum ShootType
{
    Bullet,
    Laser,
    None
}

public class Unit : MonoBehaviour, IDamageable
{
    [SerializeField] protected UnitStat unitStat;
    protected int currentHp;
    protected int currentAttackPower;

    protected virtual void Start()
    {
        ResetStat();
    }

    public void ResetStat()
    {
        ResetHp();
        ResetAttackPower();
    }

    public void ResetHp()
    {
        currentHp = unitStat.maxHp;
    }

    public void ResetAttackPower()
    {
        currentAttackPower = unitStat.attackPower;
    }

    public virtual void TakeDamage(int damage)
    {
        currentHp -= damage;

        Debug.Log("TakeDamage");
    }
}
