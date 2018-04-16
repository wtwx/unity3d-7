using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BornFirePoint : MonoBehaviour {
    [HideInInspector]
    public bool isCreate = false;

    public GameObject fireSound = null;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(isCreate)
        {
            isCreate = false;
            if (fireSound != null)
            {
                GameObject.Instantiate(fireSound, transform.position, Quaternion.identity);
            }
        }
    }
}
