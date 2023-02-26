using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronDome : AttackTower
{
    private LineRenderer line;
    public float lineDuration;
    // Start is called before the first frame update
    protected override void Start()
    {
        Debug.Log("Did we get here");
        base.Start();
        this.line = GetComponent<LineRenderer>();
        Debug.Log("Did we get here please");
        lineDuration = 0.2f;
        this.transform.Rotate(Vector3.forward, 90);

    }

    // Update is called once per frame
    override protected void Update()
    {

        base.Update();
        //Debug.Log("Did we get here");
        float wide = this.transform.localScale.x / 3f;
        line.SetWidth(wide, wide);
        lineDuration = 0.05f;
        Vector3[] positions = new Vector3[2];
        if (Time.time - lastAttackTime < lineDuration)
        {
            Color col = new Color(1, 0, 0, (Time.time - lastAttackTime) / lineDuration);
            line.SetColors(col, col);
            line.GetPositions(positions);
            line.SetPositions(positions);
        }
        else
        {
            Color col = new Color(1, 0, 0, 0);
            line.SetColors(col, col);
            line.GetPositions(positions);
            line.SetPositions(positions);
        }
    }

    override protected void attack()
    {
        Missile[] toCheck = FindObjectsOfType<Missile>();
        for(int i = 0; i < toCheck.Length; i++)
        {
            if ((this.transform.position - toCheck[i].transform.position).magnitude < this.range && toCheck[i].cringe == false)
            {
                Instantiate(attackPrefab);
                Vector3[] pos = { this.transform.position, toCheck[i].transform.position };
                line.SetPositions(pos);
                
                lastAttackTime = Time.time;
                toCheck[i].gameObject.SetActive(false);
                DestroyImmediate(toCheck[i].gameObject);
                break;
            }
        }
        
    }
}
