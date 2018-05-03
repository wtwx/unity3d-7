using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootRespones : MonoBehaviour {
    [HideInInspector]
    public bool isHitFlag = false;
    [HideInInspector]
    public RaycastHit hitInfo;
    public float forceVal = 1.0f;
    void Awake()
    {
        if(gameObject.GetComponent<Rigidbody>()==null)
        {
            gameObject.AddComponent<Rigidbody>();
        }
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        if (isHitFlag)
        {
            isHitFlag = false;
            GetComponent<Rigidbody>().AddForce(-hitInfo.normal * forceVal, ForceMode.Impulse);
        }
    }
}
