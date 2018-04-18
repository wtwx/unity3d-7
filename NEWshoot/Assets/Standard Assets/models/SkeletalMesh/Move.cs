using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
    private float speed = 0.0f;
	// Use this for initialization
	void Start () {
        GetComponent<Animation>()["Standing"].wrapMode = WrapMode.Loop;
        GetComponent<Animation>()["Run"].wrapMode = WrapMode.Loop;
        GetComponent<Animation>()["StandingFire"].wrapMode = WrapMode.Loop;
        GetComponent<Animation>()["RunFire"].wrapMode = WrapMode.Loop;
        GetComponent<Animation>()["Crouch"].wrapMode = WrapMode.Loop;
        GetComponent<Animation>()["RunJump"].wrapMode = WrapMode.Once;

        GetComponent<Animation>()["Standing"].layer = 1;
        GetComponent<Animation>()["Run"].layer = 1;
        GetComponent<Animation>()["StandingFire"].layer = 1;
        GetComponent<Animation>()["RunFire"].layer = 1;
        GetComponent<Animation>()["Crouch"].layer = 1;
        GetComponent<Animation>()["RunJump"].layer = 2;

        GetComponent<Animation>()["RunJump"].speed = 3;
	
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(0, 0, speed);
        if (Input.GetKey(KeyCode.W))
        {
            speed = 0.15f;
            GetComponent<Animation>().CrossFade("Run",0.3f);
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            speed = 0.0f;
        }

        if (speed == 0.0f)
        {
            GetComponent<Animation>().CrossFade("Standing",0.3f);
        }

        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Rotate(0, -2, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            this.transform.Rotate(0, 2, 0);
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (speed == 0.0f)
            {
                GetComponent<Animation>().CrossFade("StandingFire", 0.1f);
            }
            else
            {
                GetComponent<Animation>().CrossFade("RunFire", 0.1f);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Animation>().CrossFade("RunJump", 0.1f);
        }

        if (Input.GetKey(KeyCode.Z))
        {
            GetComponent<Animation>().CrossFade("Crouch", 0.2f);
        }
	
	}
}
