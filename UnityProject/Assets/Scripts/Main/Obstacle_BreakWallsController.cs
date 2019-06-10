using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//壊せる床の処理です
public class Obstacle_BreakWallsController: MonoBehaviour {

    //PlayerControllerを取得します
    PlayerController playerController;
    //GameSystemを取得します
    GameSystem gameSystem;
    //SEControllerを取得します
    SEController seController;


	// Use this for initialization
	void Start () {
        //PlayerControllerを探して参照します
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        //GameSystemを探して参照します
        gameSystem = GameObject.Find("GameSystem").GetComponent<GameSystem>();
        //SEControllerを探して参照します
        seController = GameObject.Find("SEManager").GetComponent<SEController>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //アタックモード以外で当たった時
        if (collision.gameObject.CompareTag("Player") && !playerController.attackFlag == true)
        {
            seController.playSE(0);
            gameSystem.playerLife = false;
            Debug.Log("死んだ0");
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //アタックモードで当たった時（子どもオブジェクト）
        if (collision.gameObject.CompareTag("Player_Ko"))
        {
            seController.playSE(3);
            Destroy(this.gameObject);
        }
        else
        {
            Debug.Log("死んだ1");
            seController.playSE(0);
            gameSystem.playerLife = false;
        }
    }
}
