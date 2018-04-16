using UnityEngine;
using System.Collections;

public class ShootSoundCtr2 : MonoBehaviour {
	
	public AudioSource asce = null;
	
	public float timecontinue = 1.0F;
	
	// Use this for initialization
	void Start () {
	
		if( asce != null )
		{
			asce.Play();
		}
		
	}
	
	// Update is called once per frame
	void Update () {
	
		StartCoroutine(WaitForDestroy(timecontinue));
		
	}
	
	IEnumerator WaitForDestroy(float time)
	{
		yield return new WaitForSeconds(time);
		Destroy (gameObject);
	}
}
