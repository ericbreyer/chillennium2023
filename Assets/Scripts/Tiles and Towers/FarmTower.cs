using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FarmTower : Tower, IClickHandler
{
    private ArtichokeManager bank;
    private GameController controller;
    private SpriteRenderer sr;
    [SerializeField] private int myrate;
    [SerializeField] private Sprite growingSprite;
    [SerializeField] private Sprite grownSprite;
    [SerializeField] private Sprite fireSprite;
    [SerializeField] private GameObject hi;
    public new int type = 1;

    private enum GrowStste {
        dead,
        growing,
        grown,
            fire,
    }
    private GrowStste grown = GrowStste.dead;

    // Start is called before the first frame update
    void Start()
    {
        bank = GameObject.FindObjectOfType<ArtichokeManager>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        controller = FindObjectOfType<GameController>();
        hi.SetActive(false);
    }

    private void Update() {
        if (grown == GrowStste.grown) {
            sr.sprite = grownSprite;
        }
        else if(grown == GrowStste.growing) { sr.sprite = growingSprite;}

        if (grown == GrowStste.dead) {
            grown = GrowStste.growing;
            Util.SetTimeout(() => { this.grown = GrowStste.grown; }, 7000, this);
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, 100f);

        //var rand = Random.value;
        //if(rand * 100 < controller.getWarmth()) {
        //    sr.sprite = fireSprite;
        //    grown = GrowStste.fire;
        //    Util.SetTimeout(() => { this.home.detach(); Destroy(gameObject); }, 2000, this);

        //}
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
