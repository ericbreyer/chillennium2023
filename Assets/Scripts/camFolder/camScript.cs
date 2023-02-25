using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        this.transform.eulerAngles = new Vector3(
                                        this.transform.eulerAngles.x,
                                        this.transform.eulerAngles.y,
                                        0);
    }

    // Update is called once per frame  
    void update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("we got here");
            this.transform.eulerAngles = new Vector3(
                                        this.transform.eulerAngles.x,
                                        this.transform.eulerAngles.y,
                                        this.transform.eulerAngles.z + this.transform.eulerAngles.z * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.eulerAngles = new Vector3(
                                        this.transform.eulerAngles.x,
                                        this.transform.eulerAngles.y,
                                        this.transform.eulerAngles.z + this.transform.eulerAngles.z * Time.deltaTime);
        }
    }
}
