using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour {
    // PUBLIC FIELDS
    public PlayerController Player;
    public IslandController Island;
    public CloudController Cloud;
    public int cloudNumber;

    public List<GameObject> clouds;

    // PRIVATE FIELDS
    private Transform _playerTransform;
    private Transform _islandTransform;
    private Transform _cloudTransform;

	// Use this for initialization
	void Start () {
        // Initialize Game Objects
       
        this._playerTransform = Player.GetComponent<Transform>();
        this._islandTransform = Island.GetComponent<Transform>();
        this._cloudTransform = Cloud.GetComponent<Transform>();


        // Create a list of Clouds
        this.clouds = new List<GameObject>();
        for (int count = 0; count < this.cloudNumber; count++)
        {
            this.clouds.Add(Instantiate(Cloud.gameObject));
        }

	}


    void checkCollision(CustomController other) {
		if (Vector2.Distance(this._playerTransform.position, other.gameObject.transform.position)
		   < (this.Player.height + other.Height))
		{
			if (!other.IsColliding)
			{
                Debug.Log("Collision with: " + other.Name);
				other.IsColliding = true;
			}
		}
		else
		{
			other.IsColliding = false;
		}
    }


	// Update is called once per frame
	void Update () {
        /*
        checkCollision(Island);

        foreach (var cloud in this.clouds)
        {
            checkCollision(cloud.GetComponent<CloudController>());
        }
        */

	}
}
