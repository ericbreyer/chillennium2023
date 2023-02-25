using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : PolarObject
{
    protected float lastAttackTime;
    public float attackRate;
    public float damage;
    public float speed;

    void Start()
    {
        this.lastAttackTime = Time.time;
    }


}
