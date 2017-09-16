﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// PUBLIC PROPERTIES +++++++++++++++++++++++++++++++++++++++++++++
	public float LeftBoundary;
	public float RightBoundary;

	// PUBLIC METHODS +++++++++++++++++++++++++++++++++++++++++++++++++

	// Use this for initialization
	public void Start () {
		
	}
	
	// Update is called once per frame
	public void Update () {

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
}