using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour {

    //プレイヤーコンポーネントを取得します
    public PlayerController player;
    //フレンド(赤)を格納する変数
    public int trace_Red = 0;
    //フレンド(青)を格納する変数
    public int trace_Blue = 0;
    //フレンド(赤)を格納する変数
    static public int c_trace_Red;
    //フレンド(青)を格納する変数
    static public int c_trace_Blue;

    //bool friend_Nomal;
    public bool friend_Power;
    public bool friend_Jamp;

    public bool playerLife;

    public bool stageCliar;

    static public int stageNo;


    // 自分のサウンドソースコンポーネント
   // AudioSource mainAudioSource;
    // オーディオクリップデータ
   // public AudioClip[] mainaudioClip;

    // Use this for initialization
    void Start () {
        playerLife = true;
        stageCliar = false;
        c_trace_Red = 0;
        c_trace_Blue = 0;
        // サウンドソースコンポーネント取得
        // 音データの初期化
        //mainAudioSource = gameObject.GetComponent<AudioSource>();
        // mainAudioSource.clip = mainaudioClip[0];
    }
	
	// Update is called once per frame
	void Update () {
       // mainAudioSource.PlayOneShot(mainaudioClip[0]);
        if (friend_Power==true)
        {
            player.nowPlayerState = PlayerController.NowPlayerState.PowerMoad;
        }else if (friend_Jamp==true)
        {
            player.nowPlayerState = PlayerController.NowPlayerState.JampMoad;
        }else
            player.nowPlayerState = PlayerController.NowPlayerState.NormalMoad;

        c_trace_Red = trace_Red;
        c_trace_Blue = trace_Blue;
    }
}
