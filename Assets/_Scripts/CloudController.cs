using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Range {
    public float min;
    public float max;
}


public class CloudController : MonoBehaviour {

    // FIELDS
    private float _verticalSpeed;
    private float _horizontalSpeed;

	[SerializeField] private float resetPosition;                
    [SerializeField] private Range verticalSpeed;
    [SerializeField] private Range horizontalSpeed;
	[SerializeField] private float horizontalBorder;


	// Use this for initialization
	void Start()
	{
		this._reset();
	}

	// Update is called once per frame
	void Update()
	{
		float newVerticalPosition = transform.position.y - this._verticalSpeed;
        float newHorizontalPosition = transform.position.x + this._horizontalSpeed;
        transform.position = new Vector2(newHorizontalPosition, newVerticalPosition);
		this._checkBounds();
	}

	private void _reset()
	{
        this._verticalSpeed = Random.Range(this.verticalSpeed.min, this.verticalSpeed.max);
        this._horizontalSpeed = Random.Range(this.horizontalSpeed.min, this.horizontalSpeed.max);
		float randomHorizontalPosition = Random.Range(-horizontalBorder, horizontalBorder);
		transform.position = new Vector2(randomHorizontalPosition, this.resetPosition);
	}

	private void _checkBounds()
	{
		if (transform.position.y <= -this.resetPosition)
		{
			this._reset();
		}
	}
}
