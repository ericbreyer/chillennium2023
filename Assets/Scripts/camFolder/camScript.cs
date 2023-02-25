using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camScript : MonoBehaviour
{
    // Start is called before the first frame update

    public float zoom = 1f;
    
    void Start()
    {

        this.transform.eulerAngles = new Vector3(
                                        this.transform.eulerAngles.x,
                                        this.transform.eulerAngles.y,
                                        0);
    }

    // Update is called once per frame  
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Rotate(new Vector3(0, 0, 360f * Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Rotate(new Vector3(0, 0, -360f * Time.deltaTime));
        }
    }
}
