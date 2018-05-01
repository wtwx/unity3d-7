using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BornBehavior : MonoBehaviour {

    public GameObject target = null;
    [HideInInspector]
    public bool isActive = false;

    public float waitTime = 1.0f;

    void Awake()
    {
        if(target != null)
        {
            target.SetActive(false);
        }
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(isActive)
        {
            isActive = false;
            StartCoroutine(WaitForBorn(waitTime));
        }
	}

    IEnumerator WaitForBorn(float waittime)
    {
        yield return new WaitForSeconds(waittime);
        target.SetActive(true);
        target.transform.position = transform.position;
        Destroy(gameObject);
    }
}
