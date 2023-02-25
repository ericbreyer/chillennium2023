using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//everything needs to inherit the things above it. Things attacking any tower or structure will inherit those things. Planet will not inherit enemy, only other way around

public class Planet : MonoBehaviour
{
    public float radius;
    public int numPlots;
    public float maxHealth;
    private float health;

    //list of tileholders
    private TileHolder[] plotList;
    
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        this.transform.localScale = new Vector3(radius, radius, 1);
        
        float plotSize = (2 * Mathf.PI * radius) / numPlots;

        //initializing list of tileholders
        plotList = new TileHolder[numPlots];
        for (int i = 0; i<numPlots; i++)
        {
            float theta = 360f / i;
            this.plotList[i] = Instantiate(Resources.Load<TileHolder>("Planet/TileHolder"));
            this.plotList[i].setPosPol(radius, theta);
        }
    }

    void takeDamage(float damage)
    {
        this.health -= damage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
