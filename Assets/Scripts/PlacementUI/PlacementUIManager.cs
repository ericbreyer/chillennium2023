using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementUIManager : MonoBehaviour
{

    private GameObject SelectedTower;
    [SerializeField] private GameObject GhostTower;
    private SpriteRenderer ghostTowerSR;
    private Camera cam;
    public void setSelectedTower(Tower tile) {
        SelectedTower = tile.gameObject;
        ghostTowerSR.sprite = tile.gameObject.GetComponent<SpriteRenderer>().sprite;
    }
    public GameObject getSelectedTower() {
        return SelectedTower.gameObject;
    }
    public void TowerPlaced() {
        SelectedTower = null;
    }

    private void Start() {
        ghostTowerSR = GhostTower.GetComponent<SpriteRenderer>();
        GhostTower.SetActive(false);
        cam = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(SelectedTower != null) {
            GhostTower.SetActive(true);
            var mp = cam.ScreenToWorldPoint(Input.mousePosition);
            GhostTower.transform.position = new Vector3(mp.x, mp.y, 0f);
            return;
        }
        GhostTower.SetActive(false);
    }
}
