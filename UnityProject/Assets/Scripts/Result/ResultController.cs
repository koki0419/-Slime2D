using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultController : MonoBehaviour
{

    //SceneController sceneController = new SceneController();


    //赤スコア表示用スプリット
    //0 0
    //1 1
    //2 2
    //3 3
    //4 4
    //5 5
    //6 6
    //7 7
    //8 8
    //9 9
    public Sprite[] redscoreSprite;

    //青スコア表示用スプリット
    //0 0
    //1 1
    //2 2
    //3 3
    //4 4
    //5 5
    //6 6
    //7 7
    //8 8
    //9 9
    public Sprite[] bulescoreSprite;
    //赤スコア表示用オブジェクト
    //0 1/1
    //1 1/10
    //2 1/100
    public GameObject[] redScoerUI;
    //青スコア表示用オブジェクト
    //0 1/1
    //1 1/10
    //2 1/100
    public GameObject[] blueScoerUI;

    //リザルトでステージ名用のテクスチャーです
    //0 ステージ00
    //1 ステージ01
    //2 ステージ02
    //3 ステージ03
    //4 ステージ04
    //5 ステージ05
    public Sprite[] stageNoSprite;

    public GameObject stageTitleUI;
    public GameObject exitUI;

    float clire_trace_Red;
    float clire_trace_Blue;

    // 自分のサウンドソースコンポーネント
    AudioSource audioSource;
    // オーディオクリップデータ
    public AudioClip[] audioClip;

    public int buttonSENo;

    public Sprite[] exitSprite;

    public void OnClickDownExitButton()
    {
        exitUI.gameObject.GetComponent<Image>().sprite = exitSprite[1];
    }

    public void OnClickUpExitButton()
    {
        StartCoroutine(OnResult());
    }

    public void OnClickRetryButton()
    {
        SceneController.OnGemaOver();     // リトライ時のステージ名を取得します。
    }

    //スタートコルーチン『シーン開始演出』を処理します
    IEnumerator OnResult()
    {
        //yield : ここでプログラムプログラムを一時停止
        //次のフレームまでここより先に進まない
        //スタートSEを再生します
        audioSource.PlayOneShot(audioClip[buttonSENo]);
        //0.5秒待つ
        yield return new WaitForSeconds(0.5f);
        exitUI.gameObject.GetComponent<Image>().sprite = exitSprite[0];
        SceneManager.LoadScene("Select");
    }


    // Use this for initialization
    void Start()
    {
        clire_trace_Red = GameSystem.c_trace_Red;
        clire_trace_Blue = GameSystem.c_trace_Blue;

        // サウンドソースコンポーネント取得
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audioClip[0];
        exitUI.gameObject.GetComponent<Image>().sprite = exitSprite[0];

        stageTitleUI.gameObject.GetComponent<Image>().sprite = stageNoSprite[GameSystem.stageNo];
        //赤のスコア用オブジェクトの表示をfalseにします
        for(int i=0;i< redScoerUI.Length;i++)
        {
            redScoerUI[i].SetActive(false);
        }
        //青のスコア用オブジェクトの表示をfalseにします
        for (int i = 0; i < redScoerUI.Length; i++)
        {
            blueScoerUI[i].SetActive(false);
        }

        //スコアをテクスチャーに置き換えます
        //（あか）
        if (GameSystem.c_trace_Red < 10)
        {
            //1/1
            redScoerUI[0].GetComponent<Image>().sprite = redscoreSprite[GameSystem.c_trace_Red % 10];
            redScoerUI[0].SetActive(true);
        }
        else if (GameSystem.c_trace_Red < 100)
        {
            //1/1
            redScoerUI[0].GetComponent<Image>().sprite = redscoreSprite[GameSystem.c_trace_Red % 10];
            //1/10
            redScoerUI[1].GetComponent<Image>().sprite = redscoreSprite[(GameSystem.c_trace_Red / 10) % 10];
            redScoerUI[0].SetActive(true);
            redScoerUI[1].SetActive(true);
        }
        else if (GameSystem.c_trace_Red < 1000)
        {
            //1/1
            redScoerUI[0].GetComponent<Image>().sprite = redscoreSprite[GameSystem.c_trace_Red % 10];
            //1/10
            redScoerUI[1].GetComponent<Image>().sprite = redscoreSprite[(GameSystem.c_trace_Red / 10) % 10];
            //1/100
            redScoerUI[2].GetComponent<Image>().sprite = redscoreSprite[(GameSystem.c_trace_Red / 100) % 10];
            redScoerUI[0].SetActive(true);
            redScoerUI[1].SetActive(true);
            redScoerUI[2].SetActive(true);
        }
        else if (GameSystem.c_trace_Red > 1000)
        {
            //1/1
            redScoerUI[0].GetComponent<Image>().sprite = redscoreSprite[GameSystem.c_trace_Red % 10];
            //1/10
            redScoerUI[1].GetComponent<Image>().sprite = redscoreSprite[(GameSystem.c_trace_Red / 10) % 10];
            //1/100
            redScoerUI[2].GetComponent<Image>().sprite = redscoreSprite[(GameSystem.c_trace_Red / 100) % 10];
            //1/1000
            redScoerUI[3].GetComponent<Image>().sprite = redscoreSprite[(GameSystem.c_trace_Red / 1000) % 10];
            redScoerUI[0].SetActive(true);
            redScoerUI[1].SetActive(true);
            redScoerUI[2].SetActive(true);
            redScoerUI[3].SetActive(true);
        }

        //（あお）
        if (GameSystem.c_trace_Blue < 10)
        {
            //1/1
            blueScoerUI[0].GetComponent<Image>().sprite = bulescoreSprite[GameSystem.c_trace_Blue % 10];
            blueScoerUI[0].SetActive(true);
        }
        else if(GameSystem.c_trace_Blue < 100)
        {
            //1/1
            blueScoerUI[0].GetComponent<Image>().sprite = bulescoreSprite[GameSystem.c_trace_Blue % 10];
            //1/10
            blueScoerUI[1].GetComponent<Image>().sprite = bulescoreSprite[(GameSystem.c_trace_Blue / 10) % 10];
            blueScoerUI[0].SetActive(true);
            blueScoerUI[1].SetActive(true);
        }
        else if(GameSystem.c_trace_Blue < 1000)
        {
            //1/1
            blueScoerUI[0].GetComponent<Image>().sprite = bulescoreSprite[GameSystem.c_trace_Blue % 10];
            //1/10
            blueScoerUI[1].GetComponent<Image>().sprite = bulescoreSprite[(GameSystem.c_trace_Blue / 10) % 10];
            //1/100
            blueScoerUI[2].GetComponent<Image>().sprite = bulescoreSprite[(GameSystem.c_trace_Blue / 100) % 10];
            blueScoerUI[0].SetActive(true);
            blueScoerUI[1].SetActive(true);
            blueScoerUI[2].SetActive(true);
        }
        else if (GameSystem.c_trace_Blue > 1000)
        {
            //1/1
            blueScoerUI[0].GetComponent<Image>().sprite = bulescoreSprite[GameSystem.c_trace_Blue % 10];
            //1/10
            blueScoerUI[1].GetComponent<Image>().sprite = bulescoreSprite[(GameSystem.c_trace_Blue / 10) % 10];
            //1/100
            blueScoerUI[2].GetComponent<Image>().sprite = bulescoreSprite[(GameSystem.c_trace_Blue / 100) % 10];
            //1/100
            blueScoerUI[3].GetComponent<Image>().sprite = bulescoreSprite[(GameSystem.c_trace_Blue / 1000) % 10];
            blueScoerUI[0].SetActive(true);
            blueScoerUI[1].SetActive(true);
            blueScoerUI[2].SetActive(true);
            blueScoerUI[3].SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
