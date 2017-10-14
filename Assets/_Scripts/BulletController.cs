using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

	public int verticalSpeed;

	// Use this for initialization
	void Start () {
		this.gameObject.name = "Bullet";
		this.verticalSpeed = 10;
	}

	private void _checkBounds() {
		if (transform.position.y > 245f) {
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += Vector3.up * verticalSpeed;
		this._checkBounds ();
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.name == "Enemy") {
			Destroy (gameObject);
		}
	}
}
