using UnityEngine;
using System.Collections;

public class Explosion_CloseLight : MonoBehaviour {

    public float waitTime = 0.5F;

	// Use this for initialization
	void Start () {
        StartCoroutine(WaitToDestroy(waitTime));
	}
	
	// Update is called once per frame
	void Update () {

    }

    IEnumerator WaitToDestroy(float waittime)
    {
        yield return new WaitForSeconds(waittime);
        Destroy(gameObject);
    }
}
