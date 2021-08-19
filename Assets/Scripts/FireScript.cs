using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
    public float firePeriod = 3.0F;     // Time given to the user to point the target
    public float forwardScale = 1.0F;   // Scaling distance from camera
    public float returnDelay = 1.0F;    // Delay of time before reloading
    public float fireForce = 100.0F;     // Force applied to the arrow

    private float startedTime;
    private bool fireing;
    private Rigidbody rb;
    private bool returning;

    void Start()
    {
        this.startedTime = Time.time;
        this.fireing = false;
        this.returning = false;
        this.rb = this.GetComponent<Rigidbody>();
        this.transform.position = Camera.main.transform.position + Camera.main.transform.forward * this.forwardScale;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (!this.returning)
        {
            StartCoroutine(Order());
        }
    }

    IEnumerator Order()
    {
        this.returning = true;
        yield return new WaitForSeconds(this.returnDelay);
        this.rb.velocity = new Vector3(0, 0, 0.0F);
        this.rb.position = Camera.main.transform.position + Camera.main.transform.forward * this.forwardScale;
        this.rb.useGravity = false;
        this.fireing = false;
        this.returning = false;
        this.startedTime = Time.time;
    }

    private void Update()
    {
        if (!this.fireing)
        {
            // Update the arrow orientation according to the player's camera
            transform.position = new Vector3(0.1F, 0.0F, 0.0F) + Camera.main.transform.position + Camera.main.transform.forward * this.forwardScale - ((Time.time - this.startedTime) / this.firePeriod) * Camera.main.transform.forward * this.forwardScale * 0.5F;
            transform.forward = Camera.main.transform.forward;

            // When fire period times out, fire!
            if ((Time.time - this.startedTime) >= this.firePeriod)
            {
                this.Fire(this.fireForce);
            }
        }
    }

    public void Fire(float force)
    {
        this.fireing = true;
        this.gameObject.GetComponent<Rigidbody>().useGravity = true;
        this.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * force);
    }
}
