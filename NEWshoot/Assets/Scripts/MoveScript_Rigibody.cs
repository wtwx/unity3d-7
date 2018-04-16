using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript_Rigibody : MonoBehaviour {
    public float moveSpeed = 1.0f;
    private float oldMoveSpeed = 0.0f;
    private bool isOnGround = true;
    public float jumpForce = 1.5f;
	// Use this for initialization
	void Start () {
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

        if(Input.GetKey(KeyCode.W)){
            transform.Translate(0.0f, 0.0f, Time.deltaTime * moveSpeed);
        }
        else if(Input.GetKey(KeyCode.S)){
            transform.Translate(0.0f, 0.0f, -Time.deltaTime * moveSpeed);
        }

        if(Input.GetKey(KeyCode.A)){
            transform.Translate(-Time.deltaTime * moveSpeed, 0.0f, 0.0f);
        }
        else if(Input.GetKey(KeyCode.D)){
            transform.Translate(Time.deltaTime * moveSpeed, 0.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if(isOnGround)
            {
                isOnGround = false;
                Rigidbody body = GetComponent<Rigidbody>();
                body.AddForce(new Vector3(0.0f, jumpForce, 0.0f), ForceMode.Impulse);
            }
        }
		
	}

void OnCollisionStay(Collision collisionInfo)
    {
        if (collisionInfo.collider.gameObject.name == "Terrain")
        {
            isOnGround = true;
        }
    }
}
