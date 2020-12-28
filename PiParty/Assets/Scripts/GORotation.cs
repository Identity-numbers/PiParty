using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GORotation : MonoBehaviour
{
    private bool toggleBool = true;
    private bool doRotate = true;

    public float rotationsPerMinute = 10.0f;

    private Vector3 originalPosition;
    private Quaternion originalRotation;

    void Update()
    {
        if (toggleBool)
            transform.Rotate(0, 1.0f * rotationsPerMinute * Time.deltaTime, 0);
    }

    void Awake()
    {
        this.originalPosition = this.transform.position;
        this.originalRotation = this.transform.rotation;
    }

    public void resetTransform()
    {
        this.transform.position = this.originalPosition;
        this.transform.rotation = this.originalRotation;
    }

    public void setToggleValue(bool val)
    {
        if (val == false)
        {
            //return to origin position
            resetTransform();
            toggleBool = false;
            doRotate = false;
        }
        else
        {
            //allow rotation
            toggleBool = true;
            doRotate = true;
        }

    }
}
