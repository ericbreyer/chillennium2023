using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTower : Tower
{
    protected float lastAttackTime;
    protected CircleCollider2D cc;
    public float attackRate;
    protected GameObject attackPrefab;
    public float range;
    public float damage;
    public LayerMask lm;
    protected ContactFilter2D cf;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        lastAttackTime = Time.time;
        cc = this.GetComponent<CircleCollider2D>();
        cc.radius = this.range / this.transform.localScale.x;
        cc.isTrigger = true;
        cf = new ContactFilter2D();
        cf.SetLayerMask(lm);
        this.attackPrefab = Resources.Load<GameObject>("Prefabs/Missile");
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - this.lastAttackTime > attackRate)
        {
            attack();
        }
    }

    protected virtual void attack()
    {
        Instantiate(attackPrefab);
        lastAttackTime = Time.time;
    }
}
