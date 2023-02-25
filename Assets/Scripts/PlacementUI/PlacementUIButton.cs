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
    // Start is called before the first frame update
    void Start()
    {
        puim = FindObjectOfType<PlacementUIManager>();
        b = GetComponent<Button>();
        b.onClick.AddListener(SetSelectedTile);
    }

    public void SetSelectedTile() {
        puim.setSelectedTower(tile);
        Debug.Log("PRESSED");
    }
}
