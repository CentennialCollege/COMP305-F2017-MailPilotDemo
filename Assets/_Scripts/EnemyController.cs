using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
	[SerializeField] private float resetPosition;
	[SerializeField] private float horizontalSpeed;
	[SerializeField] private float horizontalBorder;

	public AudioSource Explosion;

	// Use this for initialization
	void Start () {
		this._reset ();
	}
	
	// Update is called once per frame
	void Update () {
		float newHorizontalPosition = transform.position.x + this.horizontalSpeed;
		transform.position = new Vector2 (newHorizontalPosition, transform.position.y);
		this._checkBounds ();
	}

	private void _reset() {
		float randomHorizontalPosition = Random.Range (-horizontalBorder, horizontalBorder);
		transform.position = new Vector2 (randomHorizontalPosition, this.resetPosition);
	}

	private void _checkBounds() {
		if (transform.position.x <= -this.horizontalBorder) {
			this.horizontalSpeed *= -1;
		}

		if (transform.position.x >= this.horizontalBorder) {
			this.horizontalSpeed *= -1;
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.name == "Bullet") {
			Explosion.Play ();
			Destroy (gameObject);
		}
	}
}
