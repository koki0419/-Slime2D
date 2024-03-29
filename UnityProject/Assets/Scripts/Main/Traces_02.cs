﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//痕跡（青）のコントローラーです
public class Traces_02 : MonoBehaviour
{

    public PlayerController player;
    public GameSystem gameSystem;
    SEController seController;

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        gameSystem.trace_Blue += 1;
    //        Destroy(this.gameObject);
    //    }
    //}


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //痕跡を拾う音
            seController.playSE(7);
            gameSystem.trace_Blue += 34;
            Destroy(this.gameObject);
        }
    }
    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        gameSystem = GameObject.Find("GameSystem").GetComponent<GameSystem>();
        seController = GameObject.Find("SEManager").GetComponent<SEController>();
    }

    // Update is called once per frame
    void Update()
    {

    }


}
