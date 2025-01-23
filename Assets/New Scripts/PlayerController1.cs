using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary1
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController1 : MonoBehaviour
{
    public float speed;
    public Boundary1 boundary1;

    public GameObject shot;
    public Transform shotSpawn;

    public float fireRate;
    private float nextFire;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            GetComponent<AudioSource>().Play();
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);
        GetComponent<Rigidbody>().velocity = movement * speed;

        //Debug.Log("position x: " + GetComponent<Rigidbody>().position);
        if ((GetComponent<Rigidbody>().position.x > 3.5) ||
        (GetComponent<Rigidbody>().position.x < -3.5) ||
        (GetComponent<Rigidbody>().position.z < -4.5) || 
        (GetComponent<Rigidbody>().position.z > 0.5)) {
            Debug.Log("Out of bounds!");
        }

        GetComponent<Rigidbody>().position = new Vector3
		(
			Mathf.Clamp (GetComponent<Rigidbody>().position.x, boundary1.xMin, boundary1.xMax), 
			0.0f, 
			Mathf.Clamp (GetComponent<Rigidbody>().position.z, boundary1.zMin, boundary1.zMax)
		);
    }
}
