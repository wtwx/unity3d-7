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

    public bool bShowWin;
    public bool bShowSet;
    private Rect windowRect = new Rect(0, 0, Screen.width, Screen.height);
    public GUIStyle setStyle;

    public AudioSource Asc;
    public AudioSource aMyShoot;

    private int iQuality;
    private string[] QuaStrings = new string[] { "Fastest", "Fast", "Simple", "Good", "Beautiful", "Fantastic" };
	// Use this for initialization
	void Start () {
        ScWidth = Screen.width;
        ScHeight = Screen.height;
        bShowWin = false;
        bShowSet = false;
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
            Asc.Play();
            bShowWin = false;
        }
        if (GUI.Button(new Rect(-ScWidth * 0.02f, ScHeight * 0.45f, ScWidth * 0.2f, ScHeight * 0.04f), "参数设置", setStyle))
        {
            Asc.Play();
            bShowSet = !bShowSet;
        }
        if (GUI.Button(new Rect(-ScWidth * 0.02f, ScHeight * 0.5f, ScWidth * 0.2f, ScHeight * 0.04f), "退出游戏", setStyle))
        {
            Asc.Play();
            Application.Quit();
        }

        if(bShowSet==true)
        {
            GUI.DrawTexture(new Rect(ScWidth * 0.16f, ScHeight * 0.25f, ScWidth * 0.3f, ScHeight * 0.4f), sWin);
            
            aMyShoot.volume = GUI.HorizontalSlider(new Rect(ScWidth * 0.25f, ScHeight * 0.38f, ScWidth * 0.2f, ScHeight * 0.01f), aMyShoot.volume,0.0f,1.0f);

            iQuality = GUI.SelectionGrid(new Rect(ScWidth * 0.21f, ScHeight * 0.48f, ScWidth * 0.2f, ScHeight * 0.15f), iQuality, QuaStrings, 2);
        
            switch(iQuality)
            {
                case 0:
                    QualitySettings.currentLevel = QualityLevel.Fastest; 
                        break;
                case 1:
                        QualitySettings.currentLevel = QualityLevel.Fast;
                        break;
                case 2:
                        QualitySettings.currentLevel = QualityLevel.Simple;
                        break;
                case 3:
                        QualitySettings.currentLevel = QualityLevel.Good;
                        break;
                case 4:
                        QualitySettings.currentLevel = QualityLevel.Beautiful;
                        break;
                case 5:
                        QualitySettings.currentLevel = QualityLevel.Fantastic;
                        break;
            }
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
        
        if (bShowWin == true)
        {
            Time.timeScale = 0.000001f;
            Shooter.GetComponent<RotateMouse>().enabled = false;
            MainCamera.GetComponent<RotateMouse>().enabled = false;
            windowRect = GUI.Window(0, windowRect, FunWindow, "", "");
        }
        else
        {
            Time.timeScale = 1.0f;
            Shooter.GetComponent<RotateMouse>().enabled = true;
            MainCamera.GetComponent<RotateMouse>().enabled = true;
        }
    }
}
