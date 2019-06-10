using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//プレイヤーのントローラーです
public class PlayerController : MonoBehaviour
{
    //コンポーネントを事前に参照する変数
    new Rigidbody2D rigidbody;
    //移動速度を設定する
    public float moveSpeed = 5.0f;
    //ジャンプスピードを設定する
    public float jumpSpeed = 5.0f;

    public GameObject player_Ko;
    //『スライム』のテクスチャーを指定します
    //0 通常状態
    //1 パワーモード
    //2 ジャンプモード
    public Sprite[] slimeSprite;
    // 自分のアニメーションコンポーネント
    Animator animatorComponent;
    //アタック状態時間の初期化時間
    public float attackTimeValue = 5;
    //アタック状態時間を格納する変数
    float attackTime;
    // SEコントローラーを指定します
    SEController seController;
    //プレイヤーのSEの設定に使います
    //0 足音
    //1 殴る音
    //2 跳ぶ音
    //3 落ちる音
    //public int[] playerSENo;
    //public int player_WakingSE;
    //public int player_attackSE;
    //public int player_JampSE;
    //public int player_DropDownSE;

    //プレイヤーが歩行状態か判断します
    //true  歩行状態
    //false 非歩行状態
    bool wakingFlag;
    // ジャンプしているか判断
    //true ジャンプ中
    //false ジャンプしていない
    bool jampingFrag;
    //着地したかどうか判定
    //true  着地した
    //false していない
    bool landingflag;
    //アタック状態かどうかを判定するフラグ
    //true アタックモード中
    //false　アタックモードではない
    public bool attackFlag;

    public int playerSte;

    public float aninetionrosTime;
    public float aninetionrosTimeMax = 0.2f;

    //プレイヤーシーンの状態を表示します
    //1 シーン開始演出中
    //2 シーンプレイ中
    //3 ゲームオーバー演出
    public enum PlayerState
    {
        None,
        //シーン開始演出
        Start,
        //シーンプレイ中
        PlayStage,
        //ゲームオーバー演出中
        Gameover,
        //ゲームクリア演出中
        Gameclear,
    }
    //プレイヤーシーンの状態初期化します
    public PlayerState playerState = PlayerState.None;

    //プレイ中のプレイヤーの状態を表します
    //1 通常状態
    //2 パワーモード
    //3 ジャンプモード
    public enum NowPlayerState
    {
        None,
        //通常状態
        NormalMoad,
        //パワーモード
        PowerMoad,
        //パワーモード
        AttackMode,
        //ジャンプモード
        JampMoad,
    }
    //プレイ中のプレイヤーの状態を初期化します
    public NowPlayerState nowPlayerState = NowPlayerState.None;

    //プレイ中のプレイヤーのスぺシャル状態を表します
    //1　アタック状態
    public enum PlayerSpecialState
    {
        None,
        //アタック状態
        AttackMode,

    }
    //プレイ中のプレイヤーのスぺシャルの状態を初期化します
    public PlayerSpecialState playerSpecialState = PlayerSpecialState.None;


    // Use this for initialization
    void Start()
    {
        //コンポーネントを事前に参照
        rigidbody = GetComponent<Rigidbody2D>();
        //プレイヤーシーンの状態をスタート状態にします
        playerState = PlayerState.Start;
        //プレイ中のプレイヤーの状態をノーマルモード状態にします
        nowPlayerState = NowPlayerState.NormalMoad;
        //ジャンプ判定をfalse（していない）状態に設定します
        jampingFrag = false;
        //アタック状態判定をfalse（していない）状態に設定します
        attackFlag = false;
        //アタック時間を初期化します
        attackTime = attackTimeValue;
        // アニメーションコンポーネント取得
        animatorComponent = gameObject.GetComponent<Animator>();
        //SEコントローラーを参照します
        seController = GameObject.Find("SEManager").GetComponent<SEController>();
        // サウンドソースコンポーネント取得
        //audioSource = gameObject.GetComponent<AudioSource>();
        //audioSource.clip = audioClip[0];
        
    }

    // Update is called once per frame
    void Update()
    {
        //ゲーム中のコードです
        switch (playerState)
        {
            //メイン画面スタート時の処理です
            case PlayerState.Start:
                //歩行していません
                wakingFlag = false;
                //プレイヤー子のオブジェクトを非表示にします
                player_Ko.SetActive(false);
                break;
            //メイン画面プレイ中の処理です
            case PlayerState.PlayStage:
                {
                    //歩行しています
                    wakingFlag = true;

                    //（移動用）のリジットボディのベロシティーを取得します
                    var velocity = rigidbody.velocity;
                    //ボックスコライダー2Dを取得します
                    //var boxCollider2d = gameObject.GetComponent<BoxCollider2D>();
                    ////ボックスコライダー2DのSIZEを取得します
                    //Vector2 boxColliderSize = boxCollider2d.size;
                    //ボックスコライダー2DのSIZEを初期化します
                    //boxColliderSize = new Vector2(0.4f, 0.5f);
                    ////ボックスコライダー2DのSizeを格納します
                    //boxCollider2d.size = boxColliderSize;

                    //メイン画面プレイ中のプレイヤーのステータスの処理です
                    switch (nowPlayerState)
                    {
                        //通常状態
                        case NowPlayerState.NormalMoad:
                            {
                                //キャラクターのスプライトを設定します
                                GetComponent<SpriteRenderer>().sprite = slimeSprite[0];
                                //右移動を設定
                                velocity.x = moveSpeed;

                                //ジャンプボタンが押された場合
                                if (Input.GetKeyDown(KeyCode.Space))
                                {
                                    if (jampingFrag == false)
                                    {
                                        
                                        wakingFlag = false;
                                        jampingFrag = true;
                                        velocity.y = jumpSpeed;
                                    }
                                }
                                animatorComponent.SetBool("Jamp", jampingFrag);
                                playerSte = 0;
                            }
                            break;
                        //パワーモード
                        case NowPlayerState.PowerMoad:
                            {
                                //キャラクターのスプライトを設定します
                                GetComponent<SpriteRenderer>().sprite = slimeSprite[1];
                                //アニメーションの「PowerMode」を設定します
                                animatorComponent.SetBool("JampModeFlag", false);
                                animatorComponent.SetBool("PowerModeFlag", true);

                                //右移動を設定
                                velocity.x = moveSpeed;
                                //Aボタンが押された場合
                                //スペシャルモード
                                if (Input.GetKeyDown(KeyCode.A))
                                {
                                    aninetionrosTime += aninetionrosTimeMax;
                                    //アタックフラグをtrue（可能）状態に設定します
                                    attackFlag = true;
                                    //アタック状態時間を設定します
                                    attackTime = attackTimeValue;
                                    //プレイヤーのステータスをアタックモードに設定します
                                    playerSpecialState = PlayerSpecialState.AttackMode;
                                }
                                //ジャンプボタンが押された場合
                                if (Input.GetKeyDown(KeyCode.Space) && !attackFlag)
                                {
                                    if (jampingFrag == false)
                                    {
                                        wakingFlag = false;
                                        jampingFrag = true;
                                        velocity.y = jumpSpeed;
                                    }
                                }

                                //アタックモード
                                switch (playerSpecialState)
                                {
                                    case PlayerSpecialState.AttackMode:
                                        {

                                            if (attackFlag == true)
                                            {
                                                aninetionrosTime -= Time.deltaTime;
                                                animatorComponent.SetBool("AttackFlag", true);
                                                jampingFrag = false;
                                                if (aninetionrosTime <= 0)
                                                {
                                                    //var boxCollider2d = gameObject.GetComponent<BoxCollider2D>();
                                                    //Vector2 boxColliderSize = boxCollider2d.size;
                                                    //boxColliderSize = new Vector2(2.25f, 0.4f);
                                                    //boxCollider2d.size = boxColliderSize;
                                                    player_Ko.SetActive(true);
                                                    attackTime -= Time.deltaTime;
                                                    //右移動を設定
                                                    velocity.x = moveSpeed;

                                                    if (jampingFrag == true)
                                                    {
                                                        velocity.y = -5;
                                                    }

                                                    if (attackTime < 0)
                                                    {
                                                        attackFlag = false;

                                                    }
                                                }
                                            }
                                            else if (attackFlag == false)
                                            {
                                                nowPlayerState = NowPlayerState.PowerMoad;
                                                playerSpecialState = PlayerSpecialState.None;
                                                animatorComponent.SetBool("AttackFlag", false);
                                                player_Ko.SetActive(false);
                                            }
                                        }
                                        break;
                                }
                                playerSte = 1;
                            }
                            break;
                        //ジャンプモード
                        case NowPlayerState.JampMoad:
                            {
                                GetComponent<SpriteRenderer>().sprite = slimeSprite[2];
                                animatorComponent.SetBool("PowerModeFlag", false);
                                animatorComponent.SetBool("JampModeFlag", true);
                                //右移動を設定
                                velocity.x = moveSpeed;

                                //ジャンプボタンが押された場合
                                if (Input.GetKey(KeyCode.A))
                                {
                                    animatorComponent.SetBool("DashFlag", true);
                                    //右移動を設定
                                    velocity.x = moveSpeed * 1.65f;
                                }else if(Input.GetKeyUp(KeyCode.A))
                                {
                                    animatorComponent.SetBool("DashFlag", false);
                                }
                                //ジャンプボタンが押された場合
                                if (Input.GetKeyDown(KeyCode.Space))
                                {
                                    if (jampingFrag == false)
                                    {
                                        wakingFlag = false;
                                        jampingFrag = true;
                                        velocity.y = jumpSpeed;
                                    }
                                }
                                playerSte = 2;
                            }
                            break;
                    }
                    //速度を更新
                    rigidbody.velocity = velocity;

                }
                break;
            case PlayerState.Gameover:
                if (playerSte == 0)
                {
                    animatorComponent.SetBool("LifeFlag", false);
                    
                }else if (playerSte == 1)
                {
                    animatorComponent.SetBool("LifeFlag", false);
                }else if (playerSte == 2)
                {
                    animatorComponent.SetBool("LifeFlag", false);
                }
                Debug.Log("playerSte= " + playerSte);
                break;

            case PlayerState.Gameclear:
                {
                    var velocity = rigidbody.velocity;
                    //右移動を設定
                    velocity.x = moveSpeed;
                    //速度を更新
                    rigidbody.velocity = velocity;
                }
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (jampingFrag)
            {
                //animatorComponent.SetBool("Jamp", false);
                //着地した
                jampingFrag = false;
                wakingFlag = true;
            }
        }

    }
}
