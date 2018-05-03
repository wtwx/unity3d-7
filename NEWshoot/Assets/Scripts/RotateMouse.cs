using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EXORY
{
    X,
    Y,
    XY
}

public class RotateMouse : MonoBehaviour {
    public EXORY xory = EXORY.X;
    public float yMinLimit = -20.0f;
    public float yMaxLimit = 80.0f;

    public float xSpeed = 250.0f;
    public float ySpeed = 120.0f;

    private float x = 0.0f;
    private float y = 0.0f;
	// Use this for initialization
	void Start () {
        Vector3 angles = transform.eulerAngles;

        x = angles.y;
        y = angles.x;
        Rigidbody body = GetComponent<Rigidbody>();
        if(body)
        {
            body.freezeRotation = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    void LateUpdate()
    {
        switch(xory)
        {
            case EXORY.X:
                x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
                Quaternion qut1 = Quaternion.Euler(0.0f,x,0.0f);
                transform.rotation = qut1;
                break;
            case EXORY.Y:
                y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
                y = ClampAngle(y, yMinLimit, yMaxLimit);
                Quaternion qut2 = Quaternion.Euler(y,0.0f,0.0f);
                transform.rotation = qut2;
                break;
            case EXORY.XY:
                x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
                y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
                y = ClampAngle(y, yMinLimit, yMaxLimit);
                Quaternion qut3 = Quaternion.Euler(y,x,0.0f);
                transform.rotation = qut3;
                break;
         }
    }
    float ClampAngle(float angle,float min,float max)
    {
        if(angle<-360.0f)
        {
            angle += 360.0f;
        }
        if (angle > 360.0f)
        {
            angle -= 360.0f;
        }

        return Mathf.Clamp(angle, min, max);
    }
}
