using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class FarmTower : Tower, IClickHandler
{
    private ArtichokeManager bank;
    private SpriteRenderer sr;
    [SerializeField] private int rate;
    [SerializeField] private Sprite growing;
    [SerializeField] private Sprite grown;
    [SerializeField] private int cost = 10;

    // Start is called before the first frame update
    void Start()
    {
        bank = GameObject.FindObjectOfType<ArtichokeManager>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        rate = 1;
        JANK_GAME_JAM_CONSTANT_DONT_CHANGE_COST = cost;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Time.frameCount % rate == 0) {

        }
        bank.AddChokes(rate);
    }

    public void DoClick() {
        throw new System.NotImplementedException();
    }

    public void DoHoverEnter() {
        throw new System.NotImplementedException();
    }

    public void DoHoverLeave() {
        throw new System.NotImplementedException();
    }
}
