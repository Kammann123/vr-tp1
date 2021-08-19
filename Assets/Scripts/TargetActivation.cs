using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetActivation : MonoBehaviour
{
    public int step;
    private int degrees;
    private Vector3 axis;
    private Vector3 point;
    private bool activated;
    private bool transition;

    public bool Activated
    {
        get { return this.activated; }
    }

    public bool Deactivated
    {
        get { return !this.activated; }
    }

    public bool IsActivating
    {
        get { return this.activated && this.transition; }
    }

    public bool IsDeactivating
    {
        get { return !this.activated && this.transition; }
    }

    public void Activate()
    {
        this.transition = true;
        this.activated = true;
    }

    public void Deactivate()
    {
        this.transition = true;
        this.activated = false;
    }

    void Start()
    {
        this.step = 2;
        this.degrees = 0;
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
        if (this.transition)
        {
            if (!this.activated)
            {
                if (this.degrees > 0)
                {
                    this.transform.RotateAround(point, axis, -this.step);
                    this.degrees -= this.step;
                }

                if (this.degrees <= 0)
                {
                    this.transition = false;
                }
            }
            else
            {
                if (this.degrees < 90)
                {
                    this.transform.RotateAround(point, axis, this.step);
                    this.degrees += this.step;
                }

                if (this.degrees >= 90)
                {
                    this.transition = false;
                }
            }
        }
    }
}
