using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EEnemyWP
{
    NULL,
    RUN,
    STANDING,
    STANDINGFIRE,
    CROUCH,
    DEAD
}

public class WayPoint_Behavior : MonoBehaviour {

    public EEnemyWP wpBehaviour = EEnemyWP.NULL;

    [HideInInspector]
    public Collider whatCollider = null;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        whatCollider = other;
    }
}
