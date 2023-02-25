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
    public float width;
    public float height;
    public float dirdif;
    public bool dirEq;
    public bool dirConst;
    public bool dirDynam;
    public bool dirFlex;
   
    

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
        this.transform.Rotate(Vector3.forward, theta - oldtheta);
        this.transform.position = new Vector2(x, y);


        return true;
    }

    public bool setPosPol(float newR, float newTheta)
    {
        r = newR;
        theta = newTheta;
        this.transform.position = new Vector2(0, 0);
        if (dirDynam)
        {
            dir = dirdif + theta;
        }
        else if (!dirFlex)
        {

            float angle = (theta - dir);
            this.transform.Rotate(Vector3.forward, angle);
            dir = theta;
        }

        x = r * Mathf.Cos(theta * Mathf.PI / 180);
        y = r * Mathf.Sin(theta * Mathf.PI / 180);
        
        this.transform.position = new Vector2(x, y);
        
        
        

        return true;
    }

    private void Start()
    {
        
        this.transform.Rotate(Vector3.forward, -90);
        height = 1f;
        width = 1f;
    }

    private void Update()
    {
        //x = this.transform.position.x;
        //y = this.transform.position.y;
        //theta = Mathf.Atan2(x, y);
        //r = Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(y, 2));
    }

}
