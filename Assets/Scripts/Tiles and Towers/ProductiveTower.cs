using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductiveTower : Tower
{
    public ArtichokeManager bank;
    public int rate;
    
    // Start is called before the first frame update
    void Start()
    {
        bank = GameObject.FindObjectOfType<ArtichokeManager>();
        rate = 1;


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bank.AddChokes(rate);
    }
}
