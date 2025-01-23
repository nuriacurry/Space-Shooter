using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover1 : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed; //new Vector3(0,0.1)
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}