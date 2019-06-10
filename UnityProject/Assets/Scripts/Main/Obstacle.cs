using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{


    GameSystem gameSystem;
    SEController seController;

    // Use this for initialization
    void Start()
    {
        gameSystem = GameObject.Find("GameSystem").GetComponent<GameSystem>();
        seController = GameObject.Find("SEManager").GetComponent<SEController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        seController.playSE(0);
        gameSystem.playerLife = false;
    }
}
