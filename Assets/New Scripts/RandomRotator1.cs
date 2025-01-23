using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator1 : MonoBehaviour
{
    [SerializeField] private float tumble;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
    }

}
