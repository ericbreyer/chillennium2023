using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileHolder : PolarObject
{
    public Tower tower;
    public int numtowers;


    public void attach(Tower root)
    {
        tower = root;
        root.attachB(this);
    }

    void Start() 
    {
        
    }

    void Update() 
    {

    }


}
