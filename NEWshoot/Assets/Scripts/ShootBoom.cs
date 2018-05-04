using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBoom : MonoBehaviour {
    [HideInInspector]
    public bool isExplosionFlag = false;
    [HideInInspector]
    public RaycastHit rct;

    public GameObject goExplosion = null;
    public GameObject goAudioExplosion = null;
    public GameObject goMainCharacter = null;

    public float waitTime = 1.0f;

    public float damageDistance = 5.0f;
    public float expForce = 10.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isExplosionFlag)
        {
            isExplosionFlag = false;
            GameObject.Instantiate(goExplosion, rct.point, Quaternion.identity);
            goAudioExplosion.GetComponent<AudioExplosion>().goMainCharacter = goMainCharacter;
            GameObject.Instantiate(goAudioExplosion, rct.point, Quaternion.identity);
            StartCoroutine(WaitForDestroy(waitTime));
        }
	}
    IEnumerator WaitForDestroy(float waittime)
    {
        yield return new WaitForSeconds(waittime);
        Destroy(gameObject);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(gameObject.transform.position,damageDistance);
    }
}
