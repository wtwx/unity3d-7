using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMouse : MonoBehaviour {
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
            x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
            y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

            y = ClampAngle(y, yMinLimit, yMaxLimit);

            Quaternion rotation = Quaternion.Euler(y, x, 0.0f);
            transform.rotation = rotation;
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
