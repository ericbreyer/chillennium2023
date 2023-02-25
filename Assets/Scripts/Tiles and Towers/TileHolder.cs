using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileHolder : PolarObject, IClickHandler
{
    public Tower tower;
    public int numtowers;
    public ParticleSystem ps;
    public ProductiveTower productive;
    public bool empty;

    public void attach(Tower offspring)
    {
        tower = offspring;
        
        offspring.attachB(this);
        offspring.setPosPol(r + height, theta);
        offspring.createHolders();

    }

    void Start() 
    {
        ps = gameObject.GetComponent<ParticleSystem>();
        ps.Stop();
        productive = Resources.Load<ProductiveTower>("Prefabs/ProductivityTower");
        empty = true;
       
    }

    void Update() 
    {

    }

    public void DoClick()
    {
        if (empty)
        {
            tower = Instantiate(productive);
            attach(tower);
            tower.setPosPol(r + height, theta);
            empty = false;
        }
        

    }

    public void DoHoverEnter()
    {
        if(empty) ps.Play();
    }

    public void DoHoverLeave()
    {
        ps.Stop();
    }


}
