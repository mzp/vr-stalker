using UnityEngine;
using System;
using System.Collections;

public class GUIController : MonoBehaviour {

    public GUISkin customSkin = null;
    static public bool isOculusRift = true;
    private bool isLoad = false;

    void OnGUI() {
        if(customSkin) { GUI.skin = customSkin; }

        GUI.Box(new Rect(0,0,Screen.width,Screen.height),"Welcome to VR Stalker 1.0.0");
        GUI.Label(new Rect(50, 100, Screen.width - 100, 70), "Caution: 本作品には犯罪にあたる可能性のある行為が含まれています。本作品はそれらの行為を推奨するものではありません。絶対に真似をしないでください。");

        GUI.Label(new Rect(50, 170, Screen.width - 100, 70), "遊び方\n - Unityちゃんの後をこっそり追跡してください\n - Unityちゃんに3回見られるとゲームオーバーです\n - 目的地まで気づかれなければ勝ちです");

        GUIController.isOculusRift = GUI.Toggle(new Rect(50, 260, 250, 24),
                                                GUIController.isOculusRift,
                                                "OculusRiftを有効にする");

        if(isLoad) {
            GUI.Button(new Rect(50,300,Screen.width-100,35),"ロード中...");
        }else {
            if(GUI.Button(new Rect(50,300,Screen.width-100,35),"開始")){
                Application.LoadLevel("Main");
                isLoad = true;
            }
        }
    }

}
