using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BornTrigger : MonoBehaviour {

    public GameObject mainCharacter = null;
    public List<Transform> bornPoints = null;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if(mainCharacter != null)
        {
            if(other.gameObject .name ==mainCharacter .name)
            {
                foreach (Transform tf in bornPoints)
                {
                    if (tf != null && tf.gameObject .GetComponent<BornBehavior>()!=null)
                    {
                        tf.gameObject.GetComponent<BornBehavior>().isActive = true;
                    }
                }
            }
        }
    }
}
