using UnityEngine;
using System.Collections;

public class AudioExplosion : MonoBehaviour {

    public AudioSource myaudiosource = null;
    public GameObject goMainCharacter = null;
    public float temperature = 15.0F;//气温
    private float soundVelocity = 340.0F;//环境声速
    private float explosionTime = 0.0F;//爆炸开始时间点
    private bool isPlaySound = false;//是否播放声音
    private bool isPlayOnce = true;//播放只调用一次
    public float waitTime = 1.0F;//声音播放完后 多久销毁

	// Use this for initialization
	void Start () {
        myaudiosource.loop = false;
        isPlayOnce = true;

        //根据温度求环境声速
        soundVelocity = (331.3F + temperature * 0.606F)/2.0F;
        //soundVelocity = 20.05F + Mathf.Sqrt(temperature + 273.15F);

        //记录爆炸开始时间
        explosionTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if ( myaudiosource != null && goMainCharacter != null )
        {
            float passTime = Time.time - explosionTime;//声音已传播的时间
            float soundSpreadTime = (goMainCharacter.transform.position - transform.position).magnitude / soundVelocity;
            //print(soundSpreadTime);
            //print((goMainCharacter.transform.position - transform.position).magnitude);


            if ( isPlaySound )
            {
                isPlaySound = false;
                myaudiosource.Play();
                StartCoroutine(WaitToDestroy(waitTime));
            }
            else
            {
                if (passTime >= soundSpreadTime && isPlayOnce)
                {
                    isPlaySound = true;
                    isPlayOnce = false;
                }
            }
            
            
        }
    }

    IEnumerator WaitToDestroy(float waittime)
    {
        yield return new WaitForSeconds(waittime);
        Destroy(gameObject);
    }

}
