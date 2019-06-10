using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalController : MonoBehaviour {


    public GameSystem gameSystem;
    PlayerController player;

    public SEController seController;


    private void OnTriggerEnter2D(Collider2D other)
    {


        if (other.gameObject.CompareTag("Player"))
        {
            seController.playSE(2);
            gameSystem.stageCliar = true;
            player.playerState = PlayerController.PlayerState.Gameclear;
        }
    }

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player").GetComponent<PlayerController>();

    }
	
	// Update is called once per frame
	void Update () {

    }
}
