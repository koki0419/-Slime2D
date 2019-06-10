using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour {

    //ポーズボタン、リトライ＆EXIT用のテクスチャーを用意します
    //0 『Retryボタン』通常時
    //1 『Retryボタン』押されたとき
    //2 『Exitボタン』通常時
    //3 『Exitボタン』押されたとき
    public Sprite[] pauseSprite;

    //ポーズボタン、リトライ＆EXIT用のオブジェクトを取得します
    //0 『Retryボタン』
    //1 『Exitボタン』
    public GameObject[] pauseButton;

    public SEController sEController;

    public void OnClickUpExitButton()
    {
        SceneManager.LoadScene("Select");
        Time.timeScale = 1f;
        pauseButton[1].GetComponent<Image>().sprite = pauseSprite[2];
        sEController.SeButton();
    }
    //『Retryボタン』押されたとき
    public void OnClickDownExitButton()
    {
        pauseButton[1].GetComponent<Image>().sprite = pauseSprite[3];
    }

    public void OnClickUpRetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);     // リトライ時のステージ名を取得します。
        Time.timeScale = 1f;
        pauseButton[0].GetComponent<Image>().sprite = pauseSprite[0];
        sEController.SeButton();

    }
    //『Retryボタン』押されたとき
    public void OnClickDownRetryButton()
    {

        pauseButton[0].GetComponent<Image>().sprite = pauseSprite[1];
    }
    // Use this for initialization
    void Start () {
        pauseButton[0].GetComponent<Image>().sprite = pauseSprite[0];
        pauseButton[1].GetComponent<Image>().sprite = pauseSprite[2];
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
