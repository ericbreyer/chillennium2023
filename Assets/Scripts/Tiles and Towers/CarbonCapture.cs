using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CarbonCapture : Tower
{
    private GameController gm;
    [SerializeField] private float rate;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindObjectOfType<GameController>();
    }

    private void FixedUpdate() {
        if(Time.frameCount % rate == 0) {
            gm.changeWarmth(-.005f);
        }
    }
}
