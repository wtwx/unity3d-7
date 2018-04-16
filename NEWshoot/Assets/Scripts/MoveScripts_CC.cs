using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScripts_CC : MonoBehaviour {
    public float moveSpeed = 1.0f;
    private CharacterController cc = null;
    private float oldMoveSpeed = 0.0f;
	// Use this for initialization
	void Start () {
		cc=GetComponent<CharacterController>();
        oldMoveSpeed = moveSpeed;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = oldMoveSpeed * 3.5f;
        }
        else
        {
            moveSpeed = oldMoveSpeed;
        }

        if (Input.GetKey(KeyCode.W))
        {
            cc.Move(Time.deltaTime*moveSpeed*transform.forward);
        }
        else if(Input.GetKey(KeyCode.S))
        {
            cc.Move(-Time.deltaTime * moveSpeed * transform.forward);
        }

        if (Input.GetKey(KeyCode.A))
        {
            cc.Move(-Time.deltaTime * moveSpeed * transform.right);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            cc.Move(Time.deltaTime * moveSpeed * transform.right);
        }
   }
}
