using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//シーン内の状態遷移を管理します
public class SceneController : MonoBehaviour
{

    //このシーンが開始されてからの時間経過
    float gameTime = 0;
    //『シーン内メッセージ』表示用のUIを指定します
    public GameObject messageUI;

    //スタート時、ゴール時のテクスチャーです
    //0 1
    //1 2
    //2 3
    //3 スタートテクスチャー
    //4 ゴールテクスチャー
    public Sprite[] rogoSprite;
    //プレイヤーコンポーネントを参照します
    public PlayerController player;
    public UIManager uIManager;

    public SEController seController;
    public GameSystem gameSystem;


    //スタートコルーチン『シーン開始演出』を処理します
    public IEnumerator OnStartStage()
    {
        //yield : ここでプログラムプログラムを一時停止
        //次のフレームまでここより先に進まない
        messageUI.SetActive(false);
        //0.5秒待つ
        yield return new WaitForSeconds(0.5f);
        //『READY』表示
        messageUI.GetComponent<Image>().sprite = rogoSprite[2];
        messageUI.SetActive(true);
        //0.5秒待つ
        yield return new WaitForSeconds(0.5f);
        //『GO』非表示
        messageUI.SetActive(false);
        //0.5秒待つ
        yield return new WaitForSeconds(0.5f);
        //『READY』表示
        messageUI.GetComponent<Image>().sprite = rogoSprite[1];
        messageUI.SetActive(true);
        //0.5秒待つ
        yield return new WaitForSeconds(0.5f);
        //『GO』非表示
        messageUI.SetActive(false);
        //0.5秒待つ
        yield return new WaitForSeconds(0.5f);
        //『READY』表示
        messageUI.GetComponent<Image>().sprite = rogoSprite[0];
        messageUI.SetActive(true);
        //0.5秒待つ
        yield return new WaitForSeconds(0.5f);
        //『GO』非表示
        messageUI.SetActive(false);
        //0.5秒待つ
        yield return new WaitForSeconds(0.5f);
        //『READY』表示
        messageUI.GetComponent<Image>().sprite = rogoSprite[3];
        messageUI.SetActive(true);
        //0.5秒待つ
        yield return new WaitForSeconds(0.5f);
        //『GO』非表示
        messageUI.SetActive(false);
        //プレイヤーの走行開始
        player.playerState = PlayerController.PlayerState.PlayStage;
    }

    //ゲームオーバー演出コルーチン『シーン開始演出』を処理します
    IEnumerator GameOver()
    {
        //yield : ここでプログラムプログラムを一時停止
        player.playerState = PlayerController.PlayerState.Gameover;
        //次のフレームまでここより先に進まない//0.5秒待つ
        yield return new WaitForSeconds(1.0f);
        uIManager.gameOverUI.SetActive(true);
        //0.5秒待つ
        yield return new WaitForSeconds(2.0f);
        uIManager.gameOverDialog.SetActive(true);

    }

    IEnumerator StageCliar()
    {
        //yield : ここでプログラムプログラムを一時停止
        //次のフレームまでここより先に進まない
        player.playerState = PlayerController.PlayerState.Gameclear;
        //0.5秒待つ
        yield return new WaitForSeconds(1.5f);
        messageUI.GetComponent<Image>().sprite = rogoSprite[4];
        messageUI.SetActive(true);
        //0.5秒待つ
        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene("Result");

    }

    static public void OnGemaOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Use this for initialization
    void Start()
    {
        //『シーン開始演出』
        if (GameSystem.stageNo > 2)
        {
            StartCoroutine(OnStartStage());
        }


    }

    // Update is called once per frame
    void Update()
    {

        //シーン時間を進める
        //deltaTimeは前回のフレームから今回のフレームまでの差分時間
        gameTime += Time.deltaTime;

        if (gameSystem.playerLife == false)
        {
            //『シーン開始演出』
            StartCoroutine(GameOver());
        }
        if (gameSystem.stageCliar == true)
        {
            StartCoroutine(StageCliar());
        }
    }
}
