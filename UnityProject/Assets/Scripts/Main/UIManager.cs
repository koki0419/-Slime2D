using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {


    // 「Pause」UIを指定します。
    [SerializeField]
    public GameObject pauseUI;
    //ゲームオーバーUIを指定します
    public GameObject gameOverUI;
    //ゲームオーバーダイアログを指定します
    public GameObject gameOverDialog;
    //トピックUIを指定します
    public GameObject topicUI;
    //トピックボタンを指定します
    public GameObject topicstartButton;
    //「GameSystem」を指定します
    public GameSystem gameSystem;
    //「SEController」を指定します
    SEController seController;
    public SceneController sceneController;

    //トピックUIのスタートボタン用のテクスチャーを指定します
    public Sprite[] topicStartButtonSprite;

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
    //3 1/1000
    public GameObject[] redScoerUI;
    //青スコア表示用オブジェクト
    //0 1/1
    //1 1/10
    //2 1/100
    //3 1/1000
    public GameObject[] blueScoerUI;

    public void OnClickPauseButton()
    {
        // ポーズUIのアクティブ、非アクティブを切替
        pauseUI.SetActive(!pauseUI.activeSelf);

        // ポーズUIが表示されているときは停止
        if (pauseUI.activeSelf)
        {
            Time.timeScale = 0f;
            // ポーズUIが表示されていなければ通常通り進行
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void OnClickDownStartButton()
    {
        topicstartButton.GetComponent <Image>().sprite = topicStartButtonSprite[1];
    }

    public void OnClickUpStartButton()
    {
        seController.SeButton();
        topicstartButton.GetComponent<Image>().sprite = topicStartButtonSprite[0];
        topicUI.SetActive(false);
        //『シーン開始演出』
        sceneController.StartCoroutine(sceneController.OnStartStage());
        

    }
    // Use this for initialization
    void Start () {
        //各UIオブジェクト表示を非表示にします
        pauseUI.SetActive(false);
        gameOverUI.SetActive(false);
        gameOverDialog.SetActive(false);
        if (GameSystem.stageNo <= 2)
        {
            //トピックUIを表示します
            topicUI.SetActive(true);
            //スタート時にトピックのスタートボタンのテクスチャーを指定します
            topicstartButton.GetComponent<Image>().sprite = topicStartButtonSprite[0];
        }
        else
        {
            //トピックUIを非表示します
            topicUI.SetActive(false);
        }
        //赤のスコア用オブジェクトの表示をfalseにします
        for (int i = 0; i < redScoerUI.Length; i++)
        {
            redScoerUI[i].SetActive(false);
        }
        //青のスコア用オブジェクトの表示をfalseにします
        for (int i = 0; i < redScoerUI.Length; i++)
        {
            blueScoerUI[i].SetActive(false);
        }
        seController = GameObject.Find("SEManager").GetComponent<SEController>();
    }
	
	// Update is called once per frame
	void Update () {



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
        }else if(GameSystem.c_trace_Red > 1000)
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
        else if (GameSystem.c_trace_Blue < 100)
        {
            //1/1
            blueScoerUI[0].GetComponent<Image>().sprite = bulescoreSprite[GameSystem.c_trace_Blue % 10];
            //1/10
            blueScoerUI[1].GetComponent<Image>().sprite = bulescoreSprite[(GameSystem.c_trace_Blue / 10) % 10];
            blueScoerUI[0].SetActive(true);
            blueScoerUI[1].SetActive(true);
        }
        else if (GameSystem.c_trace_Blue < 1000)
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
            //1/1000
            blueScoerUI[3].GetComponent<Image>().sprite = bulescoreSprite[(GameSystem.c_trace_Blue / 1000) % 10];

            blueScoerUI[0].SetActive(true);
            blueScoerUI[1].SetActive(true);
            blueScoerUI[2].SetActive(true);
            blueScoerUI[3].SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            seController.SeButton();
            OnClickPauseButton();
        }
    }
}
