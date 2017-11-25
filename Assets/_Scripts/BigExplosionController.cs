using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BigExplosionController : MonoBehaviour {

    // Public properties
    public Animator controller;
   

    private GameController gamecontroller;



    // Use this for initialization
    void Start () {

        gamecontroller = FindObjectOfType<GameController>();

       

	}
	
	// Update is called once per frame
	void Update () {


		if(!gamecontroller.ThunderSound.isPlaying)
        {
            //Destroy(this.gameObject);

            controller.SetInteger("AnimState", 1);
        }

        if(transform.position.y < -265)
        {
            //Destroy(this.gameObject);
        }
	}
}
