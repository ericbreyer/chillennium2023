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
        this.setPosxy(basis.x, basis.y);
    }

    void Start()
    {
    }

    void Update()
    {
        
    }

}
