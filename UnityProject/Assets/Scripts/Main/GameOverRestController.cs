using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//ゲームオーバーラインの管理をしてます
public class GameOverRestController : MonoBehaviour {

    //プレイヤーを取得します
    public GameObject Player;
    //Rigidbody2Dを取得します
    Rigidbody2D rigidbody2d;
    //PlayerControllerを取得します
    PlayerController playerController;

	// Use this for initialization
	void Start () {
        //Rigidbody2Dを参照します
        rigidbody2d = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        //PlayerControllerを参照します
        playerController = GameObject .Find("Player").GetComponent<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //public void OnTrigaerEntre2D(Collision2D collision)
    //{
    //    Debug.Log("死んだ");
    //    //プレイヤーシーンの状態をスタート状態にします
    //    playerController.playerState = PlayerController.PlayerState.Gameover;

    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //プレイヤーシーンの状態をゲームオーバー状態にします
        playerController.playerState = PlayerController.PlayerState.Gameover;
    }
}
