using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileTower : AttackTower
{
    // Start is called before the first frame update
    public GameObject missile;
    protected override void Start()
    {
        base.Start();
        attackPrefab = Resources.Load<GameObject>("Attacks/Missile");
        //missile = Resources.Load<GameObject>("Attacks/Missile");
    }

    override protected void attack()
    {

        var enems = FindObjectsOfType<Enemy>();
        if(enems.Length > 0) {
            var closestEnem = enems[0];
            var dist = float.MaxValue;
            foreach(Enemy enemy in enems) {
                var newDist = new Vector2(enemy.transform.position.x - transform.position.x, enemy.transform.position.y - transform.position.y).magnitude;
                if (newDist < dist) {
                    closestEnem = enemy;
                    dist = newDist;
                }
            }
            //closestEnem.takeDamage(10f);

            Planet planet = FindObjectOfType<Planet>();
            Missile miss = Instantiate(missile).GetComponent<Missile>();
            //miss.transform.Rotate(Vector3.forward, theta - miss.theta + 180);
            miss.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

            var bruah = this.transform.up;
            bruah.Scale(new Vector3(.1f, .1f, .1f));
            miss.transform.position = this.transform.position + bruah;
            miss.setTarget(closestEnem.gameObject);
            miss.maxFlyTime = 2;
            miss.flySpeed = .2f;
            lastAttackTime = Time.time;
            miss.setLM(this.lm);
            miss.setDamage(10);
        }
    }
}
