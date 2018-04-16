using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCtr : MonoBehaviour {
    public AudioClip aSound;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void PlaySound()
    {
        AudioSource.PlayClipAtPoint(aSound, transform.position);
    }
}
