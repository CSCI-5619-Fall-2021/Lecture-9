using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        // physics code
        this.GetComponent<Rigidbody>().freezeRotation = true;
        Vector3 velocity = this.transform.rotation * new Vector3(0, speed, 0);
        this.GetComponent<Rigidbody>().velocity = velocity;
    }

    // Update is called once per frame
    void Update()
    {
        // non-physics code
        //Vector3 currentPosition = this.transform.localPosition;
        //currentPosition.z -= speed * Time.deltaTime;
        //this.transform.localPosition = currentPosition;
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Laser collision!");
    }
}
