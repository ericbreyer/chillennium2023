using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TileHolder : PolarObject, IClickHandler
{
    public Tower tower;
    public int numtowers;
    public ParticleSystem ps;
    public ProductiveTower productive;
    public bool empty;
    public SpriteRenderer sprite;

    public void attach(Tower offspring)
    {
        tower = offspring;
        
        offspring.attachB(this);
        offspring.createHolders();

    }

    void Start() 
    {
        Vector3 scale = this.transform.localScale;
        ps = gameObject.GetComponent<ParticleSystem>();
        ps.Stop();
        productive = Resources.Load<ProductiveTower>("Prefabs/ProductivityTower");

        productive.transform.localScale = scale;
        empty = true;
        sprite = GetComponent<SpriteRenderer>();
       
    }

    void Update() 
    {

    }

    public void DoClick()
    {
        if (empty)
        {
            tower = Instantiate(productive);
            tower.setPosPol(r, theta);
            Debug.Log(theta);
            
            attach(tower);
            empty = false;
            sprite.enabled = false;
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
