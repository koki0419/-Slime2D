using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//カメラの移動を管理しています
public class CameraController : MonoBehaviour {

    //プレイヤー座標を取得します
    Transform player;
	// Use this for initialization
	void Start () {
        //プレイヤーの座標を参照します
        player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        //カメラの座標を取得します
        var position = transform.position;
        //カメラポジションをプレイヤー座標に合わせます
        position.x = player.position.x + 6.5f;
        transform.position = position;
	}
}
