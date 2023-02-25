using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : PolarObject
{
    
    TileHolder home;
    Tower basis;
    int lr;
    bool towerstack;
    bool occupiedL;
    bool occupiedR;
    Tower left;
    Tower right;

    public void attachB(TileHolder basis)
    {
        home = basis;
        this.setPosxy(basis.x, basis.y);
    }

    public void attachBT(Tower inst, int side)
    {
        if(inst.attachH(this, side))
        {
            basis = inst;
            lr = side;
            towerstack = true;
        }

    }

    public bool attachH(Tower inst, int side)
    {
        if(side == 0)
        {
            if(!occupiedL)
            {
                left = inst;
                occupiedL = true;
                return true;
            }
        }
        else 
        {
            if(!occupiedL)
            {
                right = inst;
                occupiedR = true;
                return true;
            }
        }
        return false;
    }

}
