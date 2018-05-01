using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour {
    public GameObject Shooter = null;
    public Texture2D blood_b;

    private float ScWidth;
    private float ScHeight;

    public GUIStyle labelStyle;
    public GameObject MainCamera = null;
    public Texture2D tBullet;

    public Texture2D fWin;
    public Texture2D sWin;
    public Texture2D WinBack;

    private bool bShowWin;
    private Rect windowRect = new Rect(0, 0, Screen.width, Screen.height);
    public GUIStyle setStyle;
	// Use this for initialization
	void Start () {
        ScWidth = Screen.width;
        ScHeight = Screen.height;
        bShowWin = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            bShowWin = !bShowWin;
        }
	}

    void FunWindow(int WindowID)
    {
        GUI.FocusWindow(0);
        GUI.DrawTexture(new Rect(0, 0, ScWidth, ScHeight), WinBack);

        GUI.DrawTexture(new Rect(ScWidth * 0.0f, ScHeight*0.33f, ScWidth*0.15f, ScHeight*0.267f), fWin,ScaleMode.StretchToFill);

        if(GUI.Button(new Rect(-ScWidth*0.02f,ScHeight*0.4f,ScWidth*0.2f,ScHeight*0.04f),"返回游戏",setStyle))
        {

        }
        if (GUI.Button(new Rect(-ScWidth * 0.02f, ScHeight * 0.45f, ScWidth * 0.2f, ScHeight * 0.04f), "参数设置", setStyle))
        {

        }
        if (GUI.Button(new Rect(-ScWidth * 0.02f, ScHeight * 0.5f, ScWidth * 0.2f, ScHeight * 0.04f), "退出游戏", setStyle))
        {

        }
    }


    void OnGUI()
    {
        GUI.DrawTexture(new Rect(ScWidth * 0.01f, ScWidth * 0.01f, ScWidth * 0.2f, ScHeight * 0.05f), blood_b);

        labelStyle.normal.textColor = Color.red;
        float MainLife = Shooter.GetComponent<MainLife>().life;
        GUI.Label(new Rect(ScWidth * 0.12f, ScHeight * 0.025f, 100, 20), MainLife.ToString(),labelStyle);

        GUI.DrawTexture(new Rect(ScWidth * 0.03f, ScHeight * 0.95f, ScWidth * 0.03f, ScHeight * 0.05f), tBullet);
        int gunAmmoCnt = MainCamera.GetComponent<Shoot>().fAmmo;
        labelStyle.normal.textColor = Color.white;
        GUI.Label(new Rect(ScWidth * 0.08f, ScHeight * 0.96f, 100, 20),"弹药数："+gunAmmoCnt.ToString(), labelStyle);

        if(bShowWin==true)
        {
            windowRect=GUI.Window(0,windowRect,FunWindow,"","");
        }
    }
}
