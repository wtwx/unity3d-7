using System.Collections;
using UnityEngine;

public class FireSndControl : MonoBehaviour {

    public AudioSource ads = null;

    [HideInInspector]
    public bool isSndPlayOnce = true;

    public float waitTime = 0.1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (isSndPlayOnce) {
            isSndPlayOnce = false;
            StartCoroutine(WaitForPlay(waitTime));
        }
	}

    IEnumerator WaitForPlay(float waittime) {
        if (ads != null)
        {
            ads.Play();
        }
        yield return new WaitForSeconds(waittime);
        isSndPlayOnce = true;
    }
}
