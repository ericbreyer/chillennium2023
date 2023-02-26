using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : PolarObject
{
    
    public TileHolder home;
    public TileHolder left;
    public TileHolder right;
    public int lr;
    public int JANK_GAME_JAM_CONSTANT_DONT_CHANGE_COST;
    public int type;
    

    public void attachB(TileHolder basis)
    {
        home = basis;
        height = basis.height;
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
        left.setPosPol(r + transform.localScale[1] * 2 / 3, (theta + 8 / (1 + r)));
        left.dirFlex = true;
        right.setPosPol(r + transform.localScale[1] * 2 / 3, (theta - 8 / (1 + r)));
        right.dirFlex = true;
        left.transform.localScale = scale * 2/3;
        right.transform.localScale = scale * 2/3;

        right.height = height + 1;
        left.height = height + 1;


        int countr = 0;
        int countl = 0;





        //   BoxCollider2D rightColl = right.GetComponent<BoxCollider2D>();
        //    Debug.Log(rightColl.bounds.ToString());

        for (int i = 0; i < toCheck.Length; i++)
        {
            Vector2 loc = new Vector2(toCheck[i].transform.position[0], toCheck[i].transform.position[1]);
            if (Vector2.Distance(loc, new Vector2(right.x, right.y)) < Mathf.Sqrt(2) * 2 /3 * transform.localScale[0])
            {
                countr++;
            }
            if (Vector2.Distance(loc, new Vector2(left.x, left.y)) < Mathf.Sqrt(2) * 2/3 * transform.localScale[0])
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
            Destroy(left.gameObject);
        }
        if(right.tower != null)
        {
            right.tower.killChildren();
            Destroy(right.gameObject);
        }
        Destroy(this.gameObject);
    }

    void Update()
    {
        
    }

}
