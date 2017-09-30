using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Range {
    public float min;
    public float max;
}


public class CloudController : CustomController{

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
        this.Height = gameObject.GetComponent<Renderer>().bounds.extents.y;
        this.IsColliding = false;
        this.Name = "Cloud";
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
        //transform.Rotate(0.0f, 0.0f, Random.Range(0, 360));
        //var randomScale = Random.Range(0.5f, 1.0f);
        //transform.localScale = new Vector2(randomScale, randomScale);
	}

	private void _checkBounds()
	{
		if (transform.position.y <= -this.resetPosition)
		{
			this._reset();
		}
	}
}
