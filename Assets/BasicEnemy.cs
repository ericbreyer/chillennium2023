using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : Enemy
{
    
    private GameObject missile;

    // Start is called before the first frame update
    void Start()
    {
        missile = Resources.Load<GameObject>("Prefabs/Missile");
        
    }

    // Update is called once per frame
    void Update()
    {
       //move down until reasonable distance from surface
       if(this.r - FindObjectOfType<Planet>().radius > range * 0.85)
        {
            this.setPosPol(this.r - this.speed * Time.deltaTime, this.theta);
        }
    }

    protected override void attack()
    {
        base.attack();
        Collider2D[] results = new Collider2D[1];
        this.cf.SetLayerMask(lm);
        if (cc.OverlapCollider(this.cf, results) > 0.5f)
        {
            Missile miss = Instantiate(this.missile).GetComponent<Missile>();
            lastAttackTime = Time.time;
            miss.setLM(this.lm);
            miss.setTarget(results[0].gameObject);
            miss.setDamage(this.damage);
        }
    }
}
