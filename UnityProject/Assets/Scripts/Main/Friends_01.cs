using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//フレンド（赤）のコントローラーです
//アタックモードです
public class Friends_01 : MonoBehaviour {

    //ゲームシステムを取得します
    GameSystem gameSystem;
    //SEコントローラーを取得します
    SEController seController;

    // Use this for initialization
    void Start () {
        //SEコントローラーを参照します
        seController = GameObject.Find("SEManager").GetComponent<SEController>();
        //ゲームシステムを参照しますします
        gameSystem = GameObject.Find("GameSystem").GetComponent<GameSystem>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //プレイヤーが当たった時の処理
        if (collision.gameObject.CompareTag("Player"))
        {
            seController.playSE(4);
            gameSystem.friend_Jamp = false;
            gameSystem.friend_Power = true;
            Destroy(this.gameObject);
        }

    }
}
