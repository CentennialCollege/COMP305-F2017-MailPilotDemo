using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandController : CustomController {
	[SerializeField] private float resetPosition;
	[SerializeField] private float verticalSpeed;
	[SerializeField] private float horizontalBorder;


	// Use this for initialization
	void Start () {
        this.Height = gameObject.GetComponent<Renderer>().bounds.extents.y;
        this.IsColliding = false;
        this.Name = "Island";
		this._reset ();
	}
	
	// Update is called once per frame
	void Update () {
		float newVerticalPosition = transform.position.y - this.verticalSpeed;
		transform.position = new Vector2 (transform.position.x, newVerticalPosition);
		this._checkBounds ();
	}

	private void _reset() {
		float randomHorizontalPosition = Random.Range (-horizontalBorder, horizontalBorder);
		transform.position = new Vector2 (randomHorizontalPosition, this.resetPosition);
	}

	private void _checkBounds() {
		if (transform.position.y <= -this.resetPosition) {
			this._reset ();
		}
	}

}
