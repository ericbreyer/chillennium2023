using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TileHolder : PolarObject, IClickHandler
{
    public Tower tower;
    public int numtowers;
    public ParticleSystem ps;
    public bool empty;
    public SpriteRenderer sprite;
    private PlacementUIManager puim;
    

    public void attach(Tower offspring)
    {
        tower = offspring;
        
        offspring.attachB(this);

        offspring.createHolders();

    }

    protected override void Start() 
    {
        base.Start();
        ps = gameObject.GetComponent<ParticleSystem>();
        gameObject.GetComponent<ParticleSystem>().Stop();
        empty = true;
        sprite = GetComponent<SpriteRenderer>();
        puim = FindObjectOfType<PlacementUIManager>();
        Debug.Log(GetComponent<BoxCollider2D>().bounds.ToString());
        sprite.enabled = false;
    }

    void Update() 
    {
        if (puim.getSelectedTower() != null)
        {
            CircleCollider2D dummy = null;
            if(puim.getSelectedTower().TryGetComponent<CircleCollider2D>(out dummy))
            {
                Debug.Log("Got here");
                if (height == 0 && empty == true)
                {
                    sprite.enabled = true;
                    Debug.Log("Got here 2");
                }
            }    
            else
            {
                if(empty == true) sprite.enabled = true;
            }
        }
        else
        {
            sprite.enabled = false;
        }
    }

    public void DoClick()
    {
        var sel = puim.getSelectedTower();
        if (empty && sel != null)
        {
            puim.TowerPlaced();
            var obj = Instantiate(sel);
            tower = obj.GetComponent<Tower>();
            tower.transform.localScale = this.transform.localScale;
            tower.transform.localScale = this.transform.localScale * 3 / 2;
            tower.transform.Rotate(new Vector3(0, 0, -90));

            tower.setPosPol(r, theta);
            //Debug.Log(theta);
            


            attach(tower);
            gameObject.GetComponent<ParticleSystem>().Stop();
            empty = false;
            sprite.enabled = false;
        }
    }

    public void DoHoverEnter()
    {
        if(empty && sprite.enabled) gameObject.GetComponent<ParticleSystem>().Play();
    }

    public void DoHoverLeave()
    {
       if(empty) gameObject.GetComponent<ParticleSystem>().Stop();
    }

    public void detach()
    {
        if(!empty)
        {
            empty = true;
            tower.killChildren();
        }
    }

}
