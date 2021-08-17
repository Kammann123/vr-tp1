using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
    public Rigidbody rb;

    void Start()
    {
        this.rb = this.GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider collider)
    {
        this.rb.velocity = new Vector3(0, 0, 0);
        this.transform.position = new Vector3(0, 1, -9);
    }

    public void Fire()
    {
        this.rb.velocity = new Vector3(0, 0, 5.0F);
    }
}
