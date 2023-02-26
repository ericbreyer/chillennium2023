using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//using UnityEngine.UIElements;

public class PlacementUIButton : MonoBehaviour
{
    [SerializeField] Tower tile;
    Button b;
    private PlacementUIManager puim;
    private ArtichokeManager bank;
    private GameController gw;
    // Start is called before the first frame update
    void Start()
    {
        puim = FindObjectOfType<PlacementUIManager>();
        b = GetComponent<Button>();
        bank = FindObjectOfType<ArtichokeManager>();
        gw = FindObjectOfType<GameController>();
        b.onClick.AddListener(SetSelectedTile);
    }

    public void SetSelectedTile() {
        if(bank.UseChokes(tile.JANK_GAME_JAM_CONSTANT_DONT_CHANGE_COST) == ArtichokeManager.ValidChokeTransaction.NotEnoughChokes) {
            return;
        }
        gw.changeWarmth(tile.JANK_GAME_JAM_CONSTANT_DONT_CHANGE_CO2_COST);
        puim.setSelectedTower(tile);
        Debug.Log("PRESSED");
    }
}
