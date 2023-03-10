using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//everything needs to inherit the things above it. Things attacking any tower or structure will inherit those things. Planet will not inherit enemy, only other way around

public class Planet : PolarObject
{
    public float radius;
    public int numPlots;
    public new float maxHealth;
    public float health;

    //tileholder prefab
    private TileHolder th;

    //list of tileholders
    private TileHolder[] plotList;
    
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        health = maxHealth;
        this.transform.localScale = new Vector3(radius*2, radius*2, 1);

        
        float plotSize = (2 * Mathf.PI * radius) / (numPlots * 3/2);

        //initializing list of tileholders
        th = Resources.Load<TileHolder>("Prefabs/Planet/TileHolder");
        plotList = new TileHolder[numPlots];
        for (int i = 0; i<numPlots; i++)
        {
            float theta = 360f/numPlots * i;
            this.plotList[i] = Instantiate(th);
            this.plotList[i].setPosPol(radius, theta);
            this.plotList[i].transform.localScale = new Vector3(plotSize, plotSize, 0);
        }
    }

    public void takeDamage(float damage)
    {
        this.health -= damage;
        if(this.health <= 0)
        {
            //die
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
