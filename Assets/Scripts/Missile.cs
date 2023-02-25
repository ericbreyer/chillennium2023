using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject target;
    public float flySpeed;
    public float maxFlyTime;
    private float startFlyTime;
    public float triggerRadius;
    private LayerMask lm;
    private CircleCollider2D cc;
    private ContactFilter2D cf;
    private GameObject explosion;
    private float damage;

    void Start()
    {
        this.cc = gameObject.GetComponent<CircleCollider2D>();
        this.startFlyTime = Time.time;
        this.damage = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] results = new Collider2D[1];
        if(Vector3.Distance(this.transform.position, target.transform.position) < triggerRadius
            || cc.OverlapCollider(cf, results) > 1
            || Time.time - startFlyTime > maxFlyTime)
        {
            explode();
        }
        else
        {
            this.transform.LookAt(target.transform);
            Vector3 travel = (target.transform.position - this.transform.position).normalized * flySpeed * Time.deltaTime;
            this.transform.position += travel;
        }
    }

    void explode()
    {
        Collider2D[] results = new Collider2D[25];
        int num = cc.OverlapCollider(cf, results);
        for(int i = 0; i<Mathf.Max(num, 25); i++)
        {
            results[i].gameObject.GetComponent<PolarObject>().takeDamage(this.damage);
        }
        Instantiate(explosion);
        Destroy(this.gameObject);
    }

    public void setTarget(GameObject tar)
    {
        this.target = tar;
    }

    public void setLM(LayerMask lay)
    {
        this.lm = lay;
        this.cf.SetLayerMask(this.lm);
    }
    public void setDamage(float dmg)
    {
        this.damage = dmg;
    }
}