/* Eric Breyer, Chillenium 2023 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ArtichokeManager : MonoBehaviour
{
    private float startTime;
    private float lastTime;
    public enum ValidChokeTransaction {
        Good,
        NotEnoughChokes
    }

    private static GameObject instance = null;

    private Int32 chokes = 50;
    //useable in editor
    public TMP_Text chokesUI;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        if (instance != null) {
            Destroy(instance);
        }
        instance = this.gameObject;
    }

    public void AddChokes(Int32 chokes) {
        this.chokes += chokes;
    }
    public ValidChokeTransaction UseChokes(Int32 chokes) {
        var newChokes = this.chokes - chokes;
        if (newChokes < 0) {
            return ValidChokeTransaction.NotEnoughChokes;
        }
        this.chokes -= chokes;
        return ValidChokeTransaction.Good;

    }
    public void Update() {
        chokesUI.text = chokes.ToString();
        if(Time.time - lastTime > 3)
        {
            lastTime = Time.time;
            AddChokes(1);
        }
    }
}
