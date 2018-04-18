using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyLife : MonoBehaviour {
    [HideInInspector]
    public float life = 100.0f;

    public List<GameObject> hitAreaList;
    private bool isSndPlayOnce = true;
    public AudioSource ads = null;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (life>0.0f)
        {
            foreach (GameObject go in hitAreaList)
            {
                if(go!=null&& go.GetComponent<HitArea>()!=null && go.GetComponent<HitArea>().isHit)
                {
                    life -= go.GetComponent<HitArea>().damageValue;
                    go.GetComponent<HitArea>().Reset();
                }
            }
        }else
        {
            if(isSndPlayOnce && ads != null)
            {
                isSndPlayOnce = false;
                ads.Play();
            }
        }
	}
}
