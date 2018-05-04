using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootRespones : MonoBehaviour {
    [HideInInspector]
    public bool isHitFlag = false;
    [HideInInspector]
    public RaycastHit hitInfo;
    public float forceVal = 1.0f;
    public GameObject target = null;
    private bool isExpOnce = true;
    void Awake()
    {
        if(gameObject.GetComponent<Rigidbody>()==null)
        {
            gameObject.AddComponent<Rigidbody>();
        }
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        if (isHitFlag)
        {
            isHitFlag = false;
            GetComponent<Rigidbody>().AddForce(-hitInfo.normal * forceVal, ForceMode.Impulse);
        }

        if(target!=null&&target.GetComponent<ShootBoom>()!=null&&isExpOnce)
        {
            if(target.GetComponent<ShootBoom>().isExplosionFlag&&Vector3.Distance(transform.position,target.transform.position)<=target.GetComponent<ShootBoom>().damageDistance)
            {
                isExpOnce = false;
                Vector3 dir = (transform.position - target.transform.position).normalized;
                GetComponent<Rigidbody>().AddForce(dir*target.GetComponent<ShootBoom>().expForce*
                    (1.0f-Vector3.Distance(transform.position,target.transform.position)/target.GetComponent<ShootBoom>().damageDistance)
                    ,ForceMode.Impulse);
            }
        }
    }
}
