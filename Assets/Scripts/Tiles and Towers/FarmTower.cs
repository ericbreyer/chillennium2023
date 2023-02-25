using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class FarmTower : Tower, IClickHandler
{
    private ArtichokeManager bank;
    private SpriteRenderer sr;
    [SerializeField] private int rate;
    [SerializeField] private Sprite growingSprite;
    [SerializeField] private Sprite grownSprite;
    [SerializeField] private int cost = 10;

    private bool grown = false;

    // Start is called before the first frame update
    void Start()
    {
        bank = GameObject.FindObjectOfType<ArtichokeManager>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        JANK_GAME_JAM_CONSTANT_DONT_CHANGE_COST = cost;
    }

    private void Update() {
        if (grown) {
            sr.sprite = grownSprite;
        }
        else { sr.sprite = growingSprite;}
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!grown) {
            Util.SetTimeout(() => { this.grown = true; }, 7000, this);
        }
    }

    public void DoClick() {
        return;
    }

    public void DoHoverEnter() {
        return;
    }

    public void DoHoverLeave() {
        return;
    }
}
