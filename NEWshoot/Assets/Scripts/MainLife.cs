using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MainLife : MonoBehaviour {

    public float life = 100.0f;
    public float subValue = 1.0f;

    [HideInInspector]
    public bool isNeedCalLife = false;

    private bool isCauLifeOnce = true;

    private System.Random rdm = null;

    public int hitRatio = 100;

    public float calFreq = 1.0f;


    void Awake()
    {
        rdm = new System.Random();

    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isNeedCalLife && isCauLifeOnce)
        {
            isCauLifeOnce = false;
            StartCoroutine(WaitToResetCalLife(calFreq));

        }
	}

    void OnGUI()
    {
        //GUILayout.Label("生命值： "+life);
    }

    IEnumerator WaitToResetCalLife(float waittime)
    {
        CaculateLife();
        yield return new WaitForSeconds(waittime );
        isCauLifeOnce = true;
    }

    void CaculateLife()
    {
        try
        {
            int r = rdm.Next() % 100;
            if (r<=hitRatio)
            {
                life -= subValue;
            }
        }
        catch(System .Exception ex)
        {
            print(ex);
        }
    }
}
