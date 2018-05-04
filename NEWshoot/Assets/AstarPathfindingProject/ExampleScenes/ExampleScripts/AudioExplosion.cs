using UnityEngine;
using System.Collections;

public class AudioExplosion : MonoBehaviour {

    public AudioSource myaudiosource = null;
    public GameObject goMainCharacter = null;
    public float temperature = 15.0F;//����
    private float soundVelocity = 340.0F;//��������
    private float explosionTime = 0.0F;//��ը��ʼʱ���
    private bool isPlaySound = false;//�Ƿ񲥷�����
    private bool isPlayOnce = true;//����ֻ����һ��
    public float waitTime = 1.0F;//����������� �������

	// Use this for initialization
	void Start () {
        myaudiosource.loop = false;
        isPlayOnce = true;

        //�����¶��󻷾�����
        soundVelocity = (331.3F + temperature * 0.606F)/2.0F;
        //soundVelocity = 20.05F + Mathf.Sqrt(temperature + 273.15F);

        //��¼��ը��ʼʱ��
        explosionTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if ( myaudiosource != null && goMainCharacter != null )
        {
            float passTime = Time.time - explosionTime;//�����Ѵ�����ʱ��
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
