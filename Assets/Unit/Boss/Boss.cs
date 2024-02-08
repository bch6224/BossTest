using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Unit
{
    [SerializeField] protected List<BossPatternData> bossPatternData = new();
    protected Animator anim;
    protected void Awake()
    {
        anim = GetComponent<Animator>();
    }
}

[System.Serializable]
public class BossPatternData
{
    public AttackData attackData;
    public GameObject danger;
    public List<Transform> movePos = new();
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
