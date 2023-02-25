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
        GameObject[] toCheck = GameObject.FindGameObjectsWithTag("Shit");
        Vector3 scale = this.transform.localScale; 
        left = Resources.Load<TileHolder>("Prefabs/Planet/TileHolder");
        left = Instantiate(left);
        right = Instantiate(left);
        left.setPosPol(r + transform.localScale[1] / 2, (theta + 9));
        left.dirFlex = true;
        right.setPosPol(r + transform.localScale[1] / 2, (theta - 9));
        right.dirFlex = true;
        left.transform.localScale = scale;
        right.transform.localScale = scale;


        Debug.Log(toCheck.Length);

        int countr = 0;
        int countl = 0;





        //   BoxCollider2D rightColl = right.GetComponent<BoxCollider2D>();
        //    Debug.Log(rightColl.bounds.ToString());

        for (int i = 0; i < toCheck.Length; i++)
        {
            Vector2 loc = new Vector2(toCheck[i].transform.position[0], toCheck[i].transform.position[1]);
            if (Vector2.Distance(loc, new Vector2(right.x, right.y)) < Mathf.Sqrt(2 * Mathf.Pow(0.075f, 2)))
            {
                countr++;
            }
            if (Vector2.Distance(loc, new Vector2(left.x, left.y)) < Mathf.Sqrt(2 * Mathf.Pow(0.075f, 2)))
            {
                countl++;
            }
        }
        if (countr > 1)
        {
            Destroy(right.gameObject);
            Debug.Log(countr);

        }
        if (countl > 1)
        {
            Destroy(left.gameObject);
            Debug.Log(countl);

        }

    //    BoxCollider2D leftColl = left.GetComponent<BoxCollider2D>();
    //    Debug.Log(leftColl.bounds.ToString());
    //    for (int i = 0; i < toCheck.Length; i++)
    //    {
    //        BoxCollider2D other = toCheck[i].GetComponent<BoxCollider2D>();
    //        if (leftColl.bounds.Intersects(other.bounds))
    //        {
    //            countl++;
    //        }
    //    }




        //    if (countl > 1)
        //    {
        //        Destroy(left.gameObject);
        //        Debug.Log("yeetlul");
        //    }

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
