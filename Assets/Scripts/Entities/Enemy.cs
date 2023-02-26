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

    protected override void Start()
    {
        base.Start();
        cc = this.GetComponent<CircleCollider2D>();
        cc.radius = this.range/this.transform.localScale.x;
        cc.isTrigger = true;
        cf = new ContactFilter2D();
        cf.SetLayerMask(lm);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        Debug.Log("UPDAITGN");
        Debug.Log("TimeL " + Time.time + " " + this.attackRate);
        if (Time.time - this.lastAttackTime > this.attackRate)
        {
            Debug.Log("AIWUAFHAIUEWFBAIBFIABFDIAWBDAWIHSBD");
            attack();
            this.lastAttackTime = Time.time;
        }
    }

    virtual protected void attack()
    {

    }
}
