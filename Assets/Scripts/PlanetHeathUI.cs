using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlanetHeathUI : MonoBehaviour
{

    private int score = 0;
    public TMP_Text scoreUI;
    private int baseTime;


    // Update is called once per frame
    void Update()
    {
        score = (int) FindObjectOfType<Planet>().health;
        scoreUI.text = score.ToString();
    }
}