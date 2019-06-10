using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//フレンド（青）のコントローラーです
//ジャンプモードです
public class Friends_02 : MonoBehaviour {

    //ゲームシステムを取得します
    GameSystem gameSystem;
    //SEコントローラーを取得します
    SEController seController;

    // Use this for initialization
    void Start()
    {
        //SEコントローラーを参照します
        seController = GameObject.Find("SEManager").GetComponent<SEController>();
        //ゲームシステムを参照しますします
        gameSystem = GameObject.Find("GameSystem").GetComponent<GameSystem>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //プレイヤーが当たった時の処理
        if (collision.gameObject.CompareTag("Player"))
        {
            seController.playSE(4);
            gameSystem.friend_Jamp = true;
            gameSystem.friend_Power = false;
            Destroy(this.gameObject);
        }
    }
}

