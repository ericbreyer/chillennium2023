using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : Enemy
{
    
    private GameObject missile;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        missile = Resources.Load<GameObject>("Prefabs/Missile");
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        //move down until reasonable distance from surface
        
       if(this.r - FindObjectOfType<Planet>().radius > this.range * 0.5)
        {
            Debug.Log("We are goweofaefiaef");
            this.setPosPol(this.r - this.speed * Time.deltaTime, this.theta);
        }
    }

    protected override void attack()
    {
        
        base.attack();

        GameObject[] toCheck = GameObject.FindGameObjectsWithTag("Tower");
        bool hit = false;
        for (int i = 0; i < toCheck.Length; i++)
        {
            if (Vector3.Distance(this.transform.position, toCheck[i].transform.position) < this.range)
            {
                hit = true;
                Missile miss = Instantiate(this.missile).GetComponent<Missile>();
                miss.transform.position = this.transform.position;
                miss.transform.localScale = toCheck[i].transform.localScale;
                lastAttackTime = Time.time;
                miss.setLM(this.lm);
                miss.setTarget(toCheck[i].gameObject);
                miss.setDamage(this.damage);
            }
        }
        if (!hit)
        {
            Planet planet = FindObjectOfType<Planet>();
            Missile miss = Instantiate(this.missile).GetComponent<Missile>();
            miss.transform.position = this.transform.position;
            miss.transform.localScale = planet.gameObject.transform.localScale/10;
            lastAttackTime = Time.time;
            miss.setLM(this.lm);
            miss.setTarget(planet.gameObject);
            miss.setDamage(this.damage);
        }

        //Collider2D[] results = new Collider2D[1];
        //this.cf.SetLayerMask(lm);
        //Debug.Log("CCCCCCCC" + cc.OverlapCollider(this.cf, results));
        //if (cc.OverlapCollider(this.cf, results) > 0.5f)
        //{
        //    Debug.Log("BBBBBBBBBB");
        //    Missile miss = Instantiate(this.missile).GetComponent<Missile>();
        //    miss.transform.position = this.transform.position;
        //    miss.transform.localScale = results[0].transform.localScale;
        //    lastAttackTime = Time.time;
        //    miss.setLM(this.lm);
        //    miss.setTarget(results[0].gameObject);
        //    miss.setDamage(this.damage);
        //}
    }
}
