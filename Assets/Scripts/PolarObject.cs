using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PolarObject : MonoBehaviour
{
    public float x;
    public float y;
    public float theta; //theta
    public float r; //how high up
    public float dir;
    public float dirdif;
    public bool dirEq;
    public bool dirConst;
    public bool dirDynam;
    public GameObject prefab;
    

    public Vector2 getRect() 
    {
        Vector2 toRet = new Vector2(x, y);
        return toRet;
    }

    public Vector2 toRect(float mag, float dir)
    {
        Vector2 toRet = new Vector2(0, 0);
        toRet[0] = mag * Mathf.Cos(dir);
        toRet[1] = mag * Mathf.Sin(dir);
        return toRet;
    }

    public bool setPosxy(float newX, float newY)
    {
        float oldtheta = theta;
        dirdif = dir - theta;
        x = newX;
        y = newY;
        theta = Mathf.Atan2(x,  y);
        r = Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(y, 2));
        if(dirDynam)
        {
            dir = dirdif + theta;
        }
        else 
        {
            dir = theta;
        }
        prefab.transform.Rotate(Vector3.forward, theta - oldtheta);
        prefab.transform.position = new Vector2(x, y);


        return true;
    }

    public bool setPosPol(float newR, float newTheta)
    {
        r = newR;
        theta = newTheta;
        x = r * Mathf.Cos(theta);
        y = r * Mathf.Sin(theta);
        prefab.transform.position = new Vector2(x, y);
        if(dirDynam)
        {
            dir = dirdif + theta;
        }
        else 
        {
            dir = theta;
        }
        prefab.transform.eulerAngles = Vector3.forward * dir;
        return true;
    }

}
