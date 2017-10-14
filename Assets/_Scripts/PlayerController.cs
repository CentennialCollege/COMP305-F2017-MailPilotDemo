﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    // PUBLIC PROPERTIES +++++++++++++++++++++++++++++++++++++++++++++
    public GameController gameController;
	public float LeftBoundary;
    public float RightBoundary;

    public float height;
    public bool isColliding;

	public GameObject Bullet;
	public Transform BulletSpawn;

	// PUBLIC METHODS +++++++++++++++++++++++++++++++++++++++++++++++++

	// Use this for initialization
	public void Start () {
        this.height = gameObject.GetComponent<Renderer>().bounds.extents.y;
        this.isColliding = false;
	}

	private void _playerMove() {
		float mouseX = Camera.main.ScreenToWorldPoint (Input.mousePosition).x;

		Vector3 mousePosition = new Vector3(mouseX, -200f, 0f);

		if (mousePosition.x > this.RightBoundary) {
			mousePosition.x = this.RightBoundary;
		}

		if (mousePosition.x < this.LeftBoundary) {
			mousePosition.x = this.LeftBoundary;
		}

		// every frame set the Player's position to the mouse position
		transform.position = mousePosition; 
	}

	private void _playerFire() {
		if (Input.GetMouseButtonDown (0)) {
			Instantiate (this.Bullet, BulletSpawn.position, Quaternion.identity);
		}
	}

	// Update is called once per frame
	public void Update () {
		this._playerMove ();
		this._playerFire ();
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var other = collision.gameObject.GetComponent<CustomController>();

        if(!other.IsColliding){
            if (collision.gameObject.tag == "Island")
            {
                gameController.SetScore(gameController.GetScore() + 100, true);
            }

            if(collision.gameObject.tag == "Cloud") {
                gameController.SetLives(gameController.GetLives() - 1, true);
            }

            other.IsColliding = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        var other = collision.gameObject.GetComponent<CustomController>();
        other.IsColliding = false;
    }

}
