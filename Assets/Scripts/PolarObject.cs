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
    private float rScale = 5.0f;

    public bool dirFlex;

    public float maxHealth;
    private float health;
   
    

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
        r = Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(y, 2)) / rScale;
        if(dirDynam)
        {
            dir = dirdif + theta;
        }
        else 
        {
            dir = theta;
        }
        this.transform.Rotate(Vector3.forward, Mathf.Rad2Deg * (theta - oldtheta));
        this.transform.position = new Vector2(x, y);


        return true;
    }

    public bool setPosPol(float newR, float newTheta)
    {
      
        this.r = newR;
        theta = newTheta;
        this.transform.position = new Vector2(0, 0);
        if (dirDynam)
        x = r * rScale * Mathf.Cos(theta);
        y = r * rScale * Mathf.Sin(theta);
        this.transform.position = new Vector2(x, y);
        if(dirDynam)
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

        health = 3;
        

       // this.transform.eulerAngles = new Vector3(0f,0f,Mathf.Rad2Deg * dir - 90f);
        return true;
    }

    protected virtual void Start()
    {
        Debug.Log("Did we get here7");
        this.transform.Rotate(Vector3.forward, -90);
        height = 1f;
        width = 1f;
        this.health = this.maxHealth;
    }

    public void takeDamage(float dmg)
    {
        this.health -= dmg;
        if(this.health <= 0)
        {
            killChildren();
        }
    }
    public virtual void killChildren()
    {

    }

    private void Update()
    {
        //x = this.transform.position.x;
        //y = this.transform.position.y;
        //theta = Mathf.Atan2(x, y);
        //r = Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(y, 2));
    }

}
