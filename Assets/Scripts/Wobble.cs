using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wobble : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        GetComponent<RectTransform>().Rotate(new Vector3(0, 0, Mathf.Sin((float)Time.frameCount/100)/50));
    }
}