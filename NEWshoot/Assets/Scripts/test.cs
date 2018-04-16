using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {
    [HideInInspector]
    public int i = 0;
    [HideInInspector]
    public float f = 0.0f;
	// Use this for initialization
	void Start () {
        i = 0;
        A();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void A()
    {
       // print(i);
    }
}
