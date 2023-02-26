using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileTower : AttackTower
{
    // Start is called before the first frame update
    
    protected override void Start()
    {
        base.Start();
        attackPrefab = Resources.Load<GameObject>("Attacks/Missile");
    }

    override protected void attack()
    {
        Collider2D[] results = new Collider2D[5];
        this.cf.SetLayerMask(lm);
        if(cc.OverlapCollider(this.cf, results) > 0.5f)
        {
            Missile miss = Instantiate(this.attackPrefab).GetComponent<Missile>();
            lastAttackTime = Time.time;
            miss.setLM(this.lm);
            miss.setTarget(results[1].gameObject);
            miss.setDamage(this.damage);
        }
    }
}
