using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalWarmingManager : MonoBehaviour
{
    private static GameObject instance = null;

    private float globalWarming = 0;
    //useable in editor
    public Image gwUI;

    // Start is called before the first frame update
    void Start() {
        if (instance != null) {
            Destroy(instance);
        }
        instance = this.gameObject;
    }
    public void SetGlobalWarming(float num) {
        this.globalWarming = num;
        return;

    }
    public void Update() {
        gwUI.fillAmount = this.globalWarming;
    }
}
