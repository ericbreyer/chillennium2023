using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
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
    public int height;

    public void attach(Tower offspring)
    {
        tower = offspring;
        
        offspring.attachB(this);
        offspring.createHolders();

    }

    void Start() 
    {
        ps = gameObject.GetComponent<ParticleSystem>();
        ps.Stop();
        empty = true;
        sprite = GetComponent<SpriteRenderer>();
        puim = FindObjectOfType<PlacementUIManager>();
    }

    void Update() 
    {

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
            tower.transform.Rotate(new Vector3(0, 0, -90));

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
