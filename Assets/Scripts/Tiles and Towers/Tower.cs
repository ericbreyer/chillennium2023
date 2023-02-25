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
        setPosxy(basis.x, basis.y + 0.3f);
        

    }

    void Start()
    {
        
    }

    public void createHolders()
    {
        left = Resources.Load<TileHolder>("Prefabs/Planet/TileHolder");
        left = Instantiate(left);
        right = Instantiate(left);
        left.setPosPol(r + height, theta);
    }

    void Update()
    {
        
    }

}
