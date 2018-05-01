using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
    [HideInInspector]
    public PARTICLETYPE pt = PARTICLETYPE.NULL;
    public float ammoDis = 1000.0f;
    public LayerMask mask = -1;

    public Texture2D zhunXing = null;

    public float oldfov = 0.0f;

    public GameObject goMetal = null;
    public GameObject goConcrete = null;
    public GameObject goDirt= null;
    public GameObject goWood = null;
    public GameObject goBlood = null;

    private bool isMouseDown = false;
    private bool isFireOnce = false;

    public float fireTime = 0.1f;

    public GameObject goGunFire = null;
    public GameObject goGunSound = null;

    public int fAmmo;

    void Awake()
    {
        if(goGunFire!=null)
        {
            goGunFire.SetActive(false);
        }
    }
	// Use this for initialization
	void Start () {
        oldfov = GetComponent<Camera>().fieldOfView;
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButtonDown(0) && fAmmo>0)
        {
            isMouseDown = true;
            if(goGunFire!=null)
            {
                goGunFire.SetActive(true);
            }
            
        }
        if(Input.GetMouseButtonUp(0))
        {
            isMouseDown = false;
            if (goGunFire != null)
            {
                goGunFire.SetActive(false);
            }
        }
        if(Input.GetMouseButtonDown(1))
        {
            GetComponent<Camera>().fieldOfView = oldfov / 2.0f;
        }
        if(Input.GetMouseButtonUp(1))
        {
            GetComponent<Camera>().fieldOfView = oldfov;
        }

        if(isMouseDown&&!isFireOnce&& fAmmo>0)
        {
            StartCoroutine(WaitForShoot(fireTime));
        }
        
	}

    IEnumerator WaitForShoot(float waitTime)
    {
        MyShoot();
        isFireOnce = true;
        fAmmo--;
        yield return new WaitForSeconds(waitTime);
        isFireOnce = false;
    }

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(Screen.width / 2 - zhunXing.width / 2, Screen.height / 2 - zhunXing.height / 2,zhunXing.width,zhunXing.height), zhunXing, ScaleMode.StretchToFill, true);
    }

    void MyShoot()
    {
        if(goGunSound!=null)
        {
            goGunSound.GetComponent<BornFirePoint>().isCreate = true;
        }

        Ray ray = GetComponent<Camera>().ScreenPointToRay(new Vector3((float)(Screen.width / 2), (float)(Screen.height / 2), 0.0f));
        RaycastHit hitInfo;
        if(Physics.Raycast(ray.origin,ray.direction,out hitInfo,ammoDis,mask))
        {
            //print(hitInfo.collider.gameObject.name);
            if(hitInfo.collider.gameObject.GetComponent<ParticalType>()!=null)
            {
                pt = hitInfo.collider.gameObject.GetComponent<ParticalType>().pt;

            }
            else
            {
                pt = PARTICLETYPE.NULL;
            }
            //print(pt.ToString());
            if(hitInfo .collider.gameObject .GetComponent<HitArea>() != null)
            {
                HitArea hitareaScript = hitInfo.collider.gameObject.GetComponent<HitArea>();
                hitareaScript.isHit  = true;
                switch (hitareaScript .hitarea)
                {
                    case EHitArea.Head:
                        hitareaScript.damageValue = HitArea.headDamage;
                        pt = PARTICLETYPE.BLOOD;
                        break;
                    case EHitArea.Body:
                        hitareaScript.damageValue = HitArea.bodyDamage;
                        pt = PARTICLETYPE.BLOOD;
                        break;
                    case EHitArea.Arm:
                        hitareaScript.damageValue = HitArea.armDamage;
                        pt = PARTICLETYPE.BLOOD;
                        break;
                    case EHitArea.Leg:
                        hitareaScript.damageValue = HitArea.legDamage;
                        pt = PARTICLETYPE.BLOOD;
                        break;
                }

            }
            switch(pt)
            {
                case PARTICLETYPE.NULL:
                    break;
                case PARTICLETYPE.CONCRETE:
                    if(goConcrete!=null)
                        GameObject.Instantiate(goConcrete,hitInfo.point,Quaternion.FromToRotation(Vector3.up,hitInfo.normal));
                    break;
                case PARTICLETYPE.DIRT:
                    if(goDirt!=null)
                        GameObject.Instantiate(goDirt,hitInfo.point,Quaternion.FromToRotation(Vector3.up,hitInfo.normal));
                    break;
                case PARTICLETYPE.METAL:
                     if(goMetal!=null)
                        GameObject.Instantiate(goMetal,hitInfo.point,Quaternion.FromToRotation(Vector3.up,hitInfo.normal));
                    break;
                case PARTICLETYPE.WOOD:
                     if(goWood!=null)
                        GameObject.Instantiate(goWood,hitInfo.point,Quaternion.FromToRotation(Vector3.up,hitInfo.normal));
                    break;
                case PARTICLETYPE.BLOOD:
                    if (goBlood != null)
                        GameObject.Instantiate(goBlood, hitInfo.point, Quaternion.FromToRotation(Vector3.up, hitInfo.normal));
                    break;

            }
        }
    }
}
