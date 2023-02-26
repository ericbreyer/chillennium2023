using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SolarPannel : Tower
{
    private ArtichokeManager bank;
    [SerializeField] private int rate;

    // Start is called before the first frame update
    void Start()
    {
        bank = GameObject.FindObjectOfType<ArtichokeManager>();
    }

    private void FixedUpdate() {
        if(Time.frameCount % rate == 0) {
            bank.AddChokes(1);
        }
    }
}
