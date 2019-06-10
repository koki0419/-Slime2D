using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleController : MonoBehaviour {

    //シーンコントローラを指定します
    //public SceneController sceneController;
     GameSystem gameSystem;
    public PlayerController player;
    SEController seController;

    // Use this for initialization
    void Start () {
        gameSystem = GameObject.Find("GameSystem").GetComponent<GameSystem>();
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        seController = GameObject.Find("SEManager").GetComponent<SEController>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    //他のオブジェクトと衝突した際に呼び出される
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //プレイヤーと衝突したとき
        //タグ判定
        //if (colle.gameObject.tag == "Player") {
        //    gameOverUI.SetActive(true);
        //}

        //レイヤーで判定する場合→フィジクス2Dをかまう場合はif文いらない
        //ビット計算
        //if文で判定する場合（複数のレイヤーが含まれている場合）
        /*ビット計算でPlayerのレイヤーは8^2＝256で指定されている
         * 
         */
        //if (playerLayer & (1 << collision.gameObject.layer))> 0){
        //    Debug.Log("GameOver");
        //}
        seController.playSE(0);
        gameSystem.playerLife = false;
        

    }
}
