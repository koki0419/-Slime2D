using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//SEを管理します
public class SEController : MonoBehaviour
{


    // 自分のサウンドソースコンポーネント
    AudioSource audioSource;
    // オーディオクリップデータ
    // 0  ゲームオバー音① SE_01_01
    // 1  ゲームオバー音② SE_01_02
    // 2  ゲームクリア音   SE_01_03
    // 3  箱を壊す音       SE_01_04
    // 4  合体音①         SE_01_05
    // 5  合体音②         SE_01_06
    // 6  合体音③         SE_01_07
    // 7  痕跡吸収音       SE_01_08
    // 8  青スライム走音   SE_01_09
    // 9  ボタン音         SE_007
    // 10 グチャ音         GutyaOn

    public AudioClip[] audioClip;

    public int buttonSENo;

    // Use this for initialization
    void Start()
    {
        // サウンドソースコンポーネント取得
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audioClip[0];
    }

    public void StopSE()
    {
        audioSource.Stop();
    }
    public void SeButton()
    {
        //スタートSEを再生します
        audioSource.PlayOneShot(audioClip[buttonSENo]);
    }
    public void playSE(int playSENo)
    {
        //スタートSEを再生します
        audioSource.PlayOneShot(audioClip[playSENo]);
    }



    // Update is called once per frame
    void Update()
    {

    }
}
