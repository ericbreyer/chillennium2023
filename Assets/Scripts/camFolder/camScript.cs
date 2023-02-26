using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class camScript : MonoBehaviour
{
    // Start is called before the first frame update

    public float zoom = 1f;
    
    void Start()
    {

        this.transform.parent.eulerAngles = new Vector3(
                                        this.transform.eulerAngles.x,
                                        this.transform.eulerAngles.y,
                                        0);
    }

    // Update is called once per frame  
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)|| Input.GetKey(KeyCode.A))
        {
            this.transform.parent.Rotate(new Vector3(0, 0, 360f * Time.deltaTime)/zoom);
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.parent.Rotate(new Vector3(0, 0, -360f * Time.deltaTime)/zoom);
        }
        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            float y = transform.localPosition[1];
            if(zoom < 3)
            {
                zoom = zoom + Time.deltaTime;
                transform.localPosition = new Vector3(0, (zoom - 0.8f)/3, -2);
                Camera thing = gameObject.GetComponent<Camera>();
                if (zoom > 3)
                {
                    zoom = 3;
                }
                thing.orthographicSize = 1 / zoom;
            }
        }
        if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            float y = transform.localPosition[1];
            if (zoom > 0.8)
            {
                zoom = zoom - Time.deltaTime;
                transform.localPosition = new Vector3(0, (zoom - 0.8f)/3 , -2);
                Camera thing = gameObject.GetComponent<Camera>();
                if (zoom < 0.8)
                {
                    zoom = 0.8f;
                }
                thing.orthographicSize = 1 / zoom;   
            }
        }
    }
}
