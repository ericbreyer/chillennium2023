using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : PolarObject
{
    
    public TileHolder home;
    public TileHolder left;
    public TileHolder right;
    public int lr;
    

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
    }

    void Update()
    {
        
    }

}
