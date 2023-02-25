using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class FarmTower : Tower, IClickHandler
{
    private ArtichokeManager bank;
    private SpriteRenderer sr;
    [SerializeField] private int rate;
    [SerializeField] private Sprite growingSprite;
    [SerializeField] private Sprite grownSprite;
    [SerializeField] private GameObject hi;

    private enum GrowStste {
        dead,
        growing,
        grown
    }
    private GrowStste grown = GrowStste.dead;

    // Start is called before the first frame update
    void Start()
    {
        bank = GameObject.FindObjectOfType<ArtichokeManager>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        hi.SetActive(false);
    }

    private void Update() {
        if (grown == GrowStste.grown) {
            sr.sprite = grownSprite;
        }
        else { sr.sprite = growingSprite;}

        if (grown == GrowStste.dead) {
            grown = GrowStste.growing;
            Util.SetTimeout(() => { this.grown = GrowStste.grown; }, 7000, this);
        }
    }

    public void DoClick() {
        if (grown == GrowStste.grown) {
            grown = GrowStste.dead;
            bank.AddChokes(10);
            hi.SetActive(false);
        }
        return;
    }

    public void DoHoverEnter() {
        if (grown == GrowStste.grown) {
            hi.SetActive(true);
        }
        return;
    }

    public void DoHoverLeave() {
        hi.SetActive(false);
        return;
    }

    private void OnMouseOver() {
        if (grown == GrowStste.grown) {
            hi.SetActive(true);
        }
        else {
            hi.SetActive(false);
        } 
    }
}
