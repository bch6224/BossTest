using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Unit
{
    [SerializeField] protected List<AttackData> attackDatas = new();
}

[System.Serializable]
public class AttackData
{
    public GameObject bullet;
    public Transform bulletPos;
    public int bulletCount;
    public float bulletAngle;
    public ShootType shootType;
}