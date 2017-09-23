using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanController : MonoBehaviour {
	// PRIVATE INSTANCE VARIABLES
	[SerializeField] private float topPosition;
	[SerializeField] private float verticalSpeed;
	[SerializeField] private float topBoundary;


	// Use this for initialization
	void Start () {
		this._reset ();
	}
	
	// Update is called once per frame
	void Update () {
		float newVerticalPosition = transform.position.y - this.verticalSpeed;
		transform.position = new Vector2 (0f, newVerticalPosition);
		this._checkBounds ();
	}

	/// <summary>
	/// Reset the vertical position of the ocean object to the top position
	/// </summary>
	private void _reset() {
		transform.position = new Vector2 (0f, this.topPosition);
	}

	/// <summary>
	/// Checks if the ocean reaches the Top Boundary of the Screen.
	/// Then calls the _reset method.
	/// </summary>
	private void _checkBounds() {
		if (transform.position.y <= this.topBoundary) {
			this._reset ();
		}
	}
}
