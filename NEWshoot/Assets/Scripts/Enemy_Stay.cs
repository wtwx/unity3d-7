using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EEnemyStatus
{
    Crouch,
    StandingFire,
    Dead
}

public class Enemy_Stay : MonoBehaviour {

    private EEnemyStatus enemyStatus = EEnemyStatus.Crouch;
    private bool isDead = false;
    private bool isChangeStatus = true;
    public float waittime = 1.0f;
    public float doneTime = 0.2f;
    public GameObject gunFire = null;
    public Transform mainTarget = null;
    public float rotationSpeed = 2.0f;
    private bool isDeadPlayOnce = true;
    public float destroyTime = 5.0f;
    private EnemyLife enemyLife = null;

    void Awake() {
        GetComponent<Animation>().wrapMode = WrapMode.Loop;
    }

	// Use this for initialization
	void Start () {
        enemyLife = GetComponent<EnemyLife>();
	}
	
	// Update is called once per frame
	void Update () { 
		if(enemyLife.life <= 0.0f)
        {
            isDead = true;
        }

       // print(isDead);
	}

    void FixedUpdate(){
        SearchTheTarget();
        StatusBehaviour();
        AnimationPlay();
    }


    void StatusBehaviour() {
        if (!isDead)
        {
            if (isChangeStatus) {
                isChangeStatus = false;
                StartCoroutine(WaitForChange(waittime));
            }
        }
        else {
            enemyStatus = EEnemyStatus.Dead;
        }
    }

    IEnumerator WaitForChange(float waittime) {
        yield return new WaitForSeconds(waittime);
        StatusControl();
        isChangeStatus = true;
    }

    void StatusControl() {
        switch (enemyStatus){
            case EEnemyStatus.Crouch:
                enemyStatus = EEnemyStatus.StandingFire;
                if (gunFire !=null)
                {
                    gunFire.GetComponent<FireSndControl>().isSndPlayOnce=true;
                }
                break;
            case EEnemyStatus.StandingFire:
                enemyStatus = EEnemyStatus.Crouch;
                break;

        }
    }

    void AnimationPlay() {
        switch(enemyStatus){
            case EEnemyStatus.Crouch:
                GetComponent<Animation>().CrossFade("Crouch",doneTime);
                if (gunFire != null) {
                    gunFire.SetActive(false);
                }
            break;
            case EEnemyStatus.StandingFire:
                GetComponent<Animation>().CrossFade("StandingFire", doneTime);
                if (gunFire != null)
                {
                    gunFire.SetActive(true);
                }
                break;
            case EEnemyStatus.Dead:
                ToDead();
                 if (gunFire != null)
                {
                    gunFire.SetActive(false);
                }
                //GetComponent<Animation>().CrossFade("Crouch", doneTime);
                break;

        }
    }

    void ToDead() {
        if(isDeadPlayOnce)
        {
            isDeadPlayOnce = false;
            GetComponent<Animation>().wrapMode = WrapMode.Once;
            StartCoroutine(WaitForDestroy(destroyTime) );
        }
    }


    IEnumerator WaitForDestroy(float waittime)
    {
        GetComponent<Animation>().CrossFade("Dead", doneTime);
        yield return new WaitForSeconds(waittime);
        Destroy(gameObject);
    }

    void SearchTheTarget() {
        Quaternion destRotation;
        Vector3 relativePos;

        Vector3 tap;
        Vector3 trp;

        tap = mainTarget.position;
        trp = transform.position;
        tap.y = 0.0f;
        trp.y = 0.0f;
        relativePos = tap - trp;

        destRotation = Quaternion.LookRotation(relativePos);
        transform.rotation = Quaternion.Slerp(transform .rotation ,destRotation ,rotationSpeed );
    }
}
