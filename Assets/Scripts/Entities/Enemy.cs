using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{

    
    protected CircleCollider2D cc;
    public float range;
    public LayerMask lm;
    protected ContactFilter2D cf;

    // Start is called before the first frame update
    public float spawnChance;

    void Start()
    {
        this.lastAttackTime = Time.time;
        cc = this.GetComponent<CircleCollider2D>();
        cc.radius = this.range;
        cc.isTrigger = true;
        cf = new ContactFilter2D();
        cf.SetLayerMask(lm);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - this.lastAttackTime > this.attackRate)
        {
            attack();
        }
    }

    virtual protected void attack()
    {

    }
}
