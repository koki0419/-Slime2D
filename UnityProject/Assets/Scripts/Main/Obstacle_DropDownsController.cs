using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_DropDownsController : MonoBehaviour {

    Rigidbody2D rigidbody2d;

	// Use this for initialization
	void Start () {
        rigidbody2d=gameObject.GetComponent<Rigidbody2D>();
        rigidbody2d.isKinematic = true ;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            rigidbody2d.isKinematic = false; 
        }

    }
}
