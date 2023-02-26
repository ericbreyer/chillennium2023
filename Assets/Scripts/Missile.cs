using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : PolarObject
{
    // Start is called before the first frame update
    public GameObject target = null;
    public float flySpeed;
    public float maxFlyTime;
    private float startFlyTime;
    public float triggerRadius;
    private LayerMask lm;
    private CircleCollider2D cc;
    private ContactFilter2D cf;
    private Explosion explosion;
    private float damage;

    public bool cringe = false ;

    protected void Awake()
    {
        base.Start();
        this.startFlyTime = Time.time;
        cc = this.GetComponent<CircleCollider2D>();
        cc.radius = 0.3f;
        cc.isTrigger = true;
        cf = new ContactFilter2D();
        cf.SetLayerMask(lm);
        this.explosion = Resources.Load<Explosion>("Prefabs/Explosion");
        flySpeed = 0.1f;
        damage = 10;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //this.transform.position = (target.transform.position - this.transform.position) * Time.deltaTime + this.transform.position;
        //Debug.Log(Vector3.up * Time.deltaTime);
        Collider2D[] results = new Collider2D[1];
        
        Vector3 goal = new Vector3(0, 0, 0);
        if (cringe)
        {
            goal = new Vector3(this.transform.position[0] * 1000, this.transform.position[1] * 1000, 0);
            this.flySpeed = 1;
        }

        if (target != null) goal = target.transform.position;
      

        if (Vector3.Distance(this.transform.position, goal) < triggerRadius)
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
            Vector3 travel = (goal - this.transform.position).normalized * Time.deltaTime;
            //Debug.Log(travel);
            this.transform.position += travel;
        }

    }

    void explode()
    {
        Collider2D[] results = new Collider2D[25];
        int num = cc.OverlapCollider(cf, results);
        bool hit = false;
        for(int i = 0; i<Mathf.Min(num, 25); i++)
        {
            Planet p;
            Tower po;
            BasicEnemy en;
            if(results[i].gameObject.TryGetComponent<Tower>(out po))
            {
                //Debug.Log("hitting Tower");
                //Debug.Log(po.transform.position);
                //Debug.Log(Vector3.Distance(cc.transform.position, po.transform.position));
                if (results[i].bounds.size[0] < 1)
                {
                    po.takeDamage(this.damage);
                    hit = true;
                }
            }
            else if(results[i].gameObject.TryGetComponent<Planet>(out p))
            {
                p.takeDamage(this.damage);
                hit = true;
            }
            else if (results[i].gameObject.TryGetComponent<BasicEnemy>(out en))
            {
                en.takeDamage(this.damage);
                hit = true;
            }
            if (hit) break;
        }
        Explosion tada =  Instantiate(explosion);
        tada.transform.SetPositionAndRotation(this.transform.position, Quaternion.identity);
        this.gameObject.SetActive(false);
        Destroy(this.gameObject);
    }

    public void setTarget(GameObject tar)
    {
        this.target = tar;
        //this.transform.Rotate(Vector3.forward, -tar.GetComponent<PolarObject>().theta - this.theta + 180);

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
