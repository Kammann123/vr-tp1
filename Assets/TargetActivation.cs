using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetActivation : MonoBehaviour
{
    public int step;

    public bool Activated 
    {
        get { return activated == true; }
    }

    public bool Deactivated
    {
        get { return activated == false; }
    }

    private int degrees;
    private Vector3 axis;
    private Vector3 point;
    private bool activated;
    private bool transition;

    public void Activate()
    {
        if (this.Deactivated)
        {
            Debug.Log("The target has been activated!");
            this.Toggle();
        }
    }

    public void Deactivate()
    {
        if (this.Activated)
        {
            Debug.Log("The target has been deactivated!");
            this.Toggle();
        }
    }

    void Start()
    {
        this.step = 2;
        this.activated = false;
        this.transition = false;
        this.axis = Vector3.left;
        this.point = new Vector3(
            this.transform.position.x,
            this.transform.position.y,
            this.transform.position.z - this.transform.lossyScale.y / 2
        );
    }

    void Update()
    {
        if (this.transition == true)
        {
            this.transform.RotateAround(point, axis, this.activated ? -this.step : this.step);
            this.degrees += this.step;
            if (this.degrees >= 90)
            {
                this.transition = false;
                this.activated = !this.activated;
            }
        }
    }

    void Toggle()
    {
        if (this.transition == false)
        {
            this.transition = true;
            this.degrees = 0;
        }
    }
}
