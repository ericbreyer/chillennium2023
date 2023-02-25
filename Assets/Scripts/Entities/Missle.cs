using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missle : MonoBehaviour
{
    [SerializeField] private float velocity = .001f;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + transform.up.x * velocity, transform.position.y + transform.up.y * velocity, 0);
    }
}
