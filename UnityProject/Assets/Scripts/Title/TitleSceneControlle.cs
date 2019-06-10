using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleSceneControlle : MonoBehaviour
{

    public GameObject eXitUI;

    public GameObject yesButton;

    public GameObject noButton;

    // 自分のサウンドソースコンポーネント
    AudioSource audioSource;
    // オーディオクリップデータ
    public AudioClip[] audioClip;
    //スタートSEを再生します
    public int startSENo;
    //ボタンSEを再生します
    public int buttonSENo;

    public GameObject startButton;

    public GameObject exitButton;
    //スタートの画像を選択します
    //0　押される前
    //1　押されたとき
    public Sprite[] startSprite;

    //EXITの画像を選択します
    //0　押される前
    //1　押されたとき
    public Sprite[] exitSprite;

    //Yesの画像を選択します
    //0　押される前
    //1　押されたとき
    public Sprite[] yesSprite;

    //Noの画像を選択します
    //0　押される前
    //1　押されたとき
    public Sprite[] noSprite;

    //Exitボタンを押したとき
    public void OnClickExitUpButton()
    {
        eXitUI.SetActive(!eXitUI.activeSelf);

        //『EXIT』ボタンの通常状態の画像を設定します
        exitButton.GetComponent<Image>().sprite = exitSprite[0];

        //スタートSEを再生します
        audioSource.PlayOneShot(audioClip[startSENo]);
    }
    //Exitボタンを離したとき
    public void OnClickExitDownButton()
    {
        exitButton.GetComponent<Image>().sprite = exitSprite[1];
    }
    //スタートボタンを押したとき
    public void OnClickStartDownButton()
    {
        startButton.GetComponent<Image>().sprite = startSprite[1];
    }
    //スタートボタンを離したとき
    public void OnClicStartUpButton()
    {
        StartCoroutine(OnStartTitle());
    }

    public void OnClickYesDownButton()
    {
        yesButton.GetComponent<Image>().sprite = yesSprite[1];
    }
    public void OnClickYesUpButton()
    {
        yesButton.GetComponent<Image>().sprite = yesSprite[0];
        Application.Quit();
    }

    public void OnClickDownNoButton()
    {
        noButton.GetComponent<Image>().sprite = noSprite[1];
    }
    public void OnClickUpNoButton()
    {
        eXitUI.SetActive(false);
        noButton.GetComponent<Image>().sprite = noSprite[0];
        //ボタンSEを再生します
        audioSource.PlayOneShot(audioClip[buttonSENo]);
    }



    //スタートコルーチン『シーン開始演出』を処理します
    IEnumerator OnStartTitle()
    {
        //yield : ここでプログラムプログラムを一時停止
        //次のフレームまでここより先に進まない
        //スタートSEを再生します
        audioSource.PlayOneShot(audioClip[startSENo]);
        //0.5秒待つ
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Select");
    }

    // Use this for initialization
    void Start()
    {
        eXitUI.SetActive(false);
        // サウンドソースコンポーネント取得
        audioSource = gameObject.GetComponent<AudioSource>();
        //audioSource.clip = audioClip[0];
        //スタートボタンの通常状態の画像を設定します
        startButton.GetComponent<Image>().sprite = startSprite[0];
        //『EXIT』ボタンの通常状態の画像を設定します
        exitButton.GetComponent<Image>().sprite = exitSprite[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // 終了のアクティブ、非アクティブを切替
            eXitUI.SetActive(!eXitUI.activeSelf);

            //ボタンSEを再生します
            audioSource.PlayOneShot(audioClip[buttonSENo]);
        }
    }
}
