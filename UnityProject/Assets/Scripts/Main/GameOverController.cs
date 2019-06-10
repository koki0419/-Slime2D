using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//ゲームオーバー時の管理をしています
public class GameOverController : MonoBehaviour {
    //
     SEController seController;

    public GameObject exitButton;
    public Sprite[] exitSprite;

    public GameObject retrybutton;
    public Sprite[] retrySprite;

    //ゲームオーバー時のExitボタンの演出
    IEnumerator OnExit_Select()
    {
        //yield : ここでプログラムプログラムを一時停止
        //次のフレームまでここより先に進まない

        seController.SeButton();
        //0.5秒待つ
        yield return new WaitForSeconds(0.5f);
        exitButton.GetComponent<Image>().sprite = exitSprite[0];
        SceneManager.LoadScene("Select");
    }

    //ゲームオーバー時のリトライボタンの演出
    IEnumerator OnRetry()
    {
        //yield : ここでプログラムプログラムを一時停止
        //次のフレームまでここより先に進まない

        seController.SeButton();
        //0.5秒待つ
        yield return new WaitForSeconds(0.5f);
        retrybutton.GetComponent<Image>().sprite = retrySprite[0];
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);     // リトライ時のステージ名を取得します。
    }
    public void OnClickUpExitButton()
    {
        StartCoroutine(OnExit_Select());
    }

    public void OnClickDownExitButton()
    {
        exitButton.GetComponent<Image>().sprite = exitSprite[1];
    }

    public void OnClickUpRetryButton()
    {
        StartCoroutine(OnRetry());

    }
    public void OnClickDownRetryButton()
    {
        retrybutton.GetComponent<Image>().sprite = retrySprite[1];

    }
    // Use this for initialization
    void Start () {
        seController = GameObject.Find("SEManager").GetComponent<SEController>();
        exitButton.GetComponent<Image>().sprite = exitSprite[0];
        retrybutton.GetComponent<Image>().sprite = retrySprite[0];
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
