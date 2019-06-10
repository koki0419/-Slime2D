using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectSceneController : MonoBehaviour
{

    public GameObject eXitUI;

    public GameObject exitButton;

    public GameObject yesButton;

    public GameObject noButton;

    public GameObject[] StageButton;

    public int stageNum;

    // 自分のサウンドソースコンポーネント
    AudioSource audioSource;
    // オーディオクリップデータ
    public AudioClip[] audioClip;
    //スタートSEを再生します
    public int buttonSENo;

    //各ステージの画像を選択します
    //偶数　押される前
    //奇数　押されたとき
    //0,1  チュートリアル
    //2,3  ステージ1
    //4,5  ステージ2
    //6,7  ステージ3
    //7,8  ステージ4
    //9,10 ステージ5
    public Sprite[] StageSprite;

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

    //各ステージに遷移します
    //00...チュートリアル
    //01...ステージ1
    //02...ステージ2
    //03...ステージ3
    //04...ステージ4
    //05...ステージ5
    //ステージボタンが押され当たとき
    public void OnClickStageButtonDown(int stageNo)
    {
        StageButton[stageNo].GetComponent<Image>().sprite = StageSprite[stageNo *2 +1];
    }
    //ステージボタンが離されたとき
    public void OnClickStageButtonUp(int stageNo)
    {
        GameSystem.stageNo = stageNo;
        StartCoroutine(OnSelectStart(stageNo));
        
    }
    //ステージボタンが離されたとき
    public void OnClickStageButton(int stageSubNo, int stageNo)
    {
        GameSystem.stageNo = stageNo;
        SceneManager.LoadScene(string.Format("Stage_{0}{0}", stageSubNo, stageNo));
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


    //Exitボタンを押したとき
    public void OnClickExitUpButton()
    {
        eXitUI.SetActive(!eXitUI.activeSelf);

        //『EXIT』ボタンの通常状態の画像を設定します
        exitButton.GetComponent<Image>().sprite = exitSprite[0];

        //ボタンSEを再生します
        audioSource.PlayOneShot(audioClip[buttonSENo]);
    }
    //Exitボタンを離したとき
    public void OnClickExitDownButton()
    {
        exitButton.GetComponent<Image>().sprite = exitSprite[1];
    }


    IEnumerator OnSelectStart(int stageNo)
    {
        //yield : ここでプログラムプログラムを一時停止
        //次のフレームまでここより先に進まない
        //ボタンSEを再生します
        audioSource.PlayOneShot(audioClip[buttonSENo]);
        //0.5秒待つ
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(string.Format("Stage_0{0}", stageNo));


    }
    // Use this for initialization
    void Start()
    {
        eXitUI.SetActive(false);
        int j = 0;
        //各ステージの通常状態の画像を設定します
        for (int i = 0; i < StageSprite.Length; i++)
        {
            if (i % 2 == 0)
            {

                StageButton[j].GetComponent<Image>().sprite = StageSprite[i];
                j++;

            }
        }
        //『EXIT』ボタンの通常状態の画像を設定します
        exitButton.GetComponent<Image>().sprite = exitSprite[0];

        // サウンドソースコンポーネント取得
        audioSource = gameObject.GetComponent<AudioSource>();
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
