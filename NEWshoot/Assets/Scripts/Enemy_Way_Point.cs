using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Way_Point : MonoBehaviour {

    public List<GameObject> WPs = null;

    private bool isDoSomething = false;

    [HideInInspector]
    public EEnemyWP wpStyle = EEnemyWP.NULL;

    public float rotationSpeed = 2.0f;

    public float moveSpeed = 5.0f;

    private CharacterController cc = null;

    public GameObject mainCharacter = null;

    public float waitTime = 1.0f;

    private int wpCount = 0;

    private bool isCoroutineOnce = true;

    public GameObject gunFire = null;

    private bool isDead = false;

    private EnemyLife enemyLife = null;

    public float destroyTime = 5.0f;

    private bool isDeadPlayOnce = true;

    public float doneTime = 0.2f;
     
	// Use this for initialization
	void Start () {
        GetComponent<Animation>().wrapMode = WrapMode.Loop;
        cc = GetComponent<CharacterController>();
        wpStyle = EEnemyWP.RUN;
        enemyLife = GetComponent<EnemyLife>();
    }
	
	// Update is called once per frame
	void Update () {
        if (enemyLife.life <= 0.0f)
        {
            isDead = true;
        }
	}

    void FixedUpdate()
    {
        if (!isDead)
        {
            foreach(GameObject go in WPs)
            {
                if(go != null&&go.GetComponent<WayPoint_Behavior>()!=null && go.GetComponent<WayPoint_Behavior>().whatCollider!=null)
                {
                if(go != null&&go.GetComponent<WayPoint_Behavior>()!=null && go.GetComponent<WayPoint_Behavior>().whatCollider!=null)
                    if (go.GetComponent<WayPoint_Behavior>().whatCollider.gameObject.name == gameObject.name)
                        {
                            if (isCoroutineOnce)
                            {
                                isCoroutineOnce = false;
                                wpCount++;
                                wpStyle = go.GetComponent<WayPoint_Behavior>().wpBehaviour;
                                isDoSomething = true;
                                StartCoroutine(WaitForDoSomeThing(waitTime ));
                            }
                        }
                   
                }
            }

            if (!isDoSomething)
            {
                if (wpCount<WPs.Count)
                {
                    RotataTo(WPs[wpCount].transform.position);
                    RunTo(WPs[wpCount].transform.position);
                }
                else
                {
                    Destroy(gameObject);
                }

            }
            else {
                if (mainCharacter != null)
                {
                    RotataTo(mainCharacter.transform.position);
                }
            }
        }
        else
        {
            wpStyle = EEnemyWP.DEAD;
        }
        AnimationPlay();
    }

    IEnumerator WaitForDoSomeThing(float waittime)
    {
        yield return new WaitForSeconds(waittime);
        isDoSomething = false;
        isCoroutineOnce = true;
        wpStyle = EEnemyWP.RUN;
        Destroy(WPs[wpCount - 1]);
    }

    void AnimationPlay()
    {
        switch (wpStyle)
        {
            case EEnemyWP.NULL:
                break;
            case EEnemyWP.RUN:
                GetComponent<Animation>().CrossFade("Run",doneTime);
                if (gunFire != null)
                {
                    gunFire.SetActive(false);
                }
                if (mainCharacter.GetComponent<MainLife>() != null)
                {
                    mainCharacter.gameObject.GetComponent<MainLife>().isNeedCalLife = false;
                }
                break;
            case EEnemyWP.STANDING:
                GetComponent<Animation>().CrossFade("Standing", doneTime);
                if (gunFire != null)
                {
                    gunFire.SetActive(false);
                }
                if (mainCharacter.GetComponent<MainLife>() != null)
                {
                    mainCharacter.gameObject.GetComponent<MainLife>().isNeedCalLife = false;
                }
                break;
            case EEnemyWP.STANDINGFIRE:
                GetComponent<Animation>().CrossFade("StandingFire", doneTime);
                if (gunFire != null)
                {
                    gunFire.SetActive(true);
                }
                if (mainCharacter.GetComponent<MainLife>() != null)
                {
                    mainCharacter.gameObject.GetComponent<MainLife>().isNeedCalLife = true;
                }
                break;
            case EEnemyWP.CROUCH:
                GetComponent<Animation>().CrossFade("Crouch", doneTime);
                if (gunFire != null)
                {
                    gunFire.SetActive(false);
                }
                if (mainCharacter.GetComponent<MainLife>() != null)
                {
                    mainCharacter.gameObject.GetComponent<MainLife>().isNeedCalLife = false;
                }
                break;
            case EEnemyWP.DEAD:
                ToDead();
                if (gunFire != null)
                {
                    gunFire.SetActive(false);
                }
                if (mainCharacter.GetComponent<MainLife>() != null)
                {
                    mainCharacter.gameObject.GetComponent<MainLife>().isNeedCalLife = false;
                }
                break;
        }

    }

    void ToDead()
    {
        if (isDeadPlayOnce)
        {
            isDeadPlayOnce = false;
            GetComponent<Animation>().wrapMode = WrapMode.Once;
            StartCoroutine(WaitForDestroy(destroyTime));
        }
    }
    IEnumerator WaitForDestroy(float waittime)
    {
        GetComponent<Animation>().CrossFade("Dead",doneTime);
        yield return new WaitForSeconds(waittime);
        foreach(GameObject go in WPs)
        {
            if (go != null)
            {
                Destroy(go);
            }
        }
        Destroy(gameObject);
    }

    void RotataTo(Vector3 othertargetpoint) {
        Quaternion destRotation;
        Vector3 relativePos;

        Vector3 tap;
        Vector3 trp;

        tap = othertargetpoint;
        trp = transform.position;
        tap.y = 0.0f;
        trp.y = 0.0f;
        relativePos = tap - trp;

        destRotation = Quaternion.LookRotation(relativePos);
        transform.rotation = Quaternion.Slerp(transform.rotation, destRotation, rotationSpeed);
    }

    void RunTo(Vector3 othertargetpoint)
    {
        Vector3 moveDirection = transform.TransformDirection(Vector3.Cross(Vector3.up,Vector3.left));
        Vector3 velocity = moveDirection.normalized*moveSpeed;

        if (cc != null)
        {
            cc.SimpleMove(velocity);
        }


    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawIcon(new Vector3(transform.position.x,transform.position.y+5.0f,transform.position.z),"strat.psd");
        Gizmos.DrawIcon(new Vector3(WPs[WPs.Count-1].transform.position.x, WPs[WPs.Count - 1].transform.position.y+1.0f, WPs[WPs.Count - 1].transform.position.z),"end.psd");
        Gizmos.DrawLine(transform.position,WPs[0].transform.position);
        for(int i = 0; i<WPs.Count; i++)
        {
            if (i != WPs.Count - 1)
            {
                Gizmos.DrawLine(WPs[i].transform.position,WPs[i+1].transform.position);
            }
        }
    }
}
