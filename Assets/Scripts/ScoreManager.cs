using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    private int score = 0;
    public TMP_Text scoreUI;
    private int baseTime;


    // Update is called once per frame
    void Update()
    {
        score = (int)Time.time - baseTime;
        Debug.LogWarning(score);
        scoreUI.text = score.ToString();
    }
    private void OnEnable() {
        baseTime = (int)Time.time;
    }
    public int GetScore() {
        return score;
    }
}