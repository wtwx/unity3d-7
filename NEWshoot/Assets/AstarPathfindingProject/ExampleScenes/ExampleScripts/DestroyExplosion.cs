using UnityEngine;
using System.Collections;

public class DestroyExplosion : MonoBehaviour {

    public float waitDestroyTime = 1.0F;//等待销毁时间

	// Use this for initialization
	void Start () {
        StartCoroutine(WaitToDestroy(waitDestroyTime));
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
