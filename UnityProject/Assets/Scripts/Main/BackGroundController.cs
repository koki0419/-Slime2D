using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//背景のスクロールを管理する
public class BackGroundController : MonoBehaviour
{
    //背景を配列で取得
    public GameObject[] panels;

    float gridsize;

    // Use this for initialization
    void Start()
    {

        //for (int i = 0; i < panels.Length; i++)
        //{
        //    panels[i] = GameObject.Find("BackGround" + i);

        //}

        //2枚の背景を綺麗に並べる
        //for (int i = 0; i < panels.Length; i++)
        //{
        //   //16:9の画像に対して
        //    float position = 16.0f / 9.0f * 10.0f * i;
        //    panels[i].transform.localPosition = new Vector2(position, 0.0f);
        //}


        //1920*1020/10(108.0f)の画像に対して位置を計算//横/高さ*Unit数
        gridsize = Screen.width * 2 * Camera.main.orthographicSize / Screen.height;

    }

    // Update is called once per frame
    void Update()
    {
       

        //カメラが現在いるグリッド
        int cameraGrid = Mathf.FloorToInt(Camera.main.transform.position.x / gridsize);
        //背景のグリッド分のUnit
        for (int i = 0; i < panels.Length; i++)
        {

            panels[i].transform.localPosition = new Vector3(gridsize * (cameraGrid + i), 0, 0);
        }
    }
}
