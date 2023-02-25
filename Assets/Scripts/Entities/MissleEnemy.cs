using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleEnemy : Enemy
{

    private const float rVelocity = -.0005f;
    private float thetaVelocity = .01f;
    private GameObject misslePrefab;
    // Start is called before the first frame update
    void Start()
    {
        var startingAngle = Random.value * Mathf.PI * 2;
        this.setPosPol(1f, startingAngle);
        this.misslePrefab = Resources.Load<GameObject>("Prefabs/Enemies/Missle");
    }

    // Update is called once per frame
    void Update()
    {
        this.setPosPol(this.r + rVelocity, this.theta + thetaVelocity);
        if (this.r <= .2f) {
            r = .2f;
        }
        var rand = Random.value * 500;
        if (rand < 1) {
            thetaVelocity = -thetaVelocity;
        }
        if(rand > 498) {
            var o = Instantiate(misslePrefab, transform.position, transform.rotation);
            o.transform.Rotate(new Vector3(0, 0, 180));
        }
    }
}