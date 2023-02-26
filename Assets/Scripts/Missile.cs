using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
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
        cc = this.GetComponent<CircleCollider2D>();
        cc.radius = 1;
        cc.isTrigger = true;
        cf = new ContactFilter2D();
        cf.SetLayerMask(lm);
        this.explosion = Resources.Load<GameObject>("Prefabs/Explosion");
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] results = new Collider2D[1];
        if (target == null)
        {
            explode();
        }
        else if (Vector3.Distance(this.transform.position, target.transform.position) < triggerRadius)
        {
            explode();
        }
        else if (cc.OverlapCollider(cf, results) >= 1)
        {
            explode();
        }
        else if (Time.time - startFlyTime > maxFlyTime)
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
        for(int i = 0; i<Mathf.Min(num, 25); i++)
        {
            Planet p;
            PolarObject po;
            if(results[i].gameObject.TryGetComponent<PolarObject>(out po))
            {
                po.takeDamage(this.damage);
            }
            else if(results[i].gameObject.TryGetComponent<Planet>(out p))
            {
                p.takeDamage(this.damage);
            }
        }
        Instantiate(explosion, this.transform);
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
