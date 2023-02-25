using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : PolarObject
{
    
    public TileHolder home;
    public TileHolder left;
    public TileHolder right;
    public int depth = 0;
    public int lr;
    public int JANK_GAME_JAM_CONSTANT_DONT_CHANGE_COST;
    

    public void attachB(TileHolder basis)
    {
        home = basis;
    }

    void Start()
    {
        
    }

    public void createHolders()
    {
        Vector3 scale = this.transform.localScale; 
        left = Resources.Load<TileHolder>("Prefabs/Planet/TileHolder");
        left = Instantiate(left);
        right = Instantiate(left);
        left.setPosPol(r + transform.localScale[1] / 2, (theta + 5));
        left.dirFlex = true;
        right.setPosPol(r + transform.localScale[1] / 2, (theta - 5));
        right.dirFlex = true;
        left.transform.localScale = scale;
        right.transform.localScale = scale;

        GameObject[] toCheck = GameObject.FindGameObjectsWithTag("Shit");
        int countr = 0;
        int countl = 0;
        Collider2D rightColl = right.GetComponent<Collider2D>();
        Collider2D leftColl = left.GetComponent<Collider2D>();
        for(int i = 0; i < toCheck.Length; i++)
        {
            Collider2D other = toCheck[i].GetComponent<Collider2D>();
            if(rightColl.bounds.Intersects(other.bounds))
            {
                countr++;
            }
            if(leftColl.bounds.Intersects(other.bounds))
            {
                countl++;
            }
        }

        if (countr > 1) Destroy(right);
        if (countl > 1) Destroy(left);
        
    }


    public override void killChildren() 
    {
        if(left.tower != null)
        {
            left.tower.killChildren();
        }
        if(right.tower != null)
        {
            right.tower.killChildren();
        }
        Destroy(this);
    }

    void Update()
    {
        
    }

}
