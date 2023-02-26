using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SolarPannel : Tower
{
    private float lastTime;
    private ArtichokeManager bank;
    public float rate;

    // Start is called before the first frame update
    void Start()
    {
        bank = GameObject.FindObjectOfType<ArtichokeManager>();
        this.lastTime = Time.time;
    }

    void Update() {
        if(Time.time - this.lastTime > rate) {
            bank.AddChokes(1);
            this.lastTime = Time.time;
        }
    }
}
