using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EHitArea
{
    Head,
    Body,
    Arm,
    Leg
}

public class HitArea : MonoBehaviour {

    [HideInInspector]
    public const float headDamage = 100.0f;

    [HideInInspector]
    public const float bodyDamage = 50.0f;

    [HideInInspector]
    public const float armDamage = 25.0f;

    [HideInInspector]
    public const float legDamage = 25.0f;

    [HideInInspector]
    public bool isHit = false;

    [HideInInspector]
    public float damageValue = 0.0f;

    public EHitArea hitarea = EHitArea.Head;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Reset()
    {
        isHit = false;
        damageValue = 0.0f;
    }
}
