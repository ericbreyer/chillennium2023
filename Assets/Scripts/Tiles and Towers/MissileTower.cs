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
        Collider2D[] results = new Collider2D[1];
        this.cf.SetLayerMask(lm);

        if(cc.OverlapCollider(this.cf, results) != 0)
        {
            Missile miss = Instantiate(this.attackPrefab).GetComponent<Missile>();
            miss.transform.localScale = results[0].transform.localScale;
            lastAttackTime = Time.time;
            miss.setLM(this.lm);
            miss.setTarget(results[0].gameObject);
            miss.setDamage(this.damage);
        }
    }
}
