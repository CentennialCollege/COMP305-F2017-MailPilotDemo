using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour {
    // PUBLIC FIELDS
    public PlayerController Player;
    public IslandController Island;
    public CloudController Cloud;
    public int cloudNumber;

    public Text ScoreLabel;
    public Text LivesLabel;

    public List<GameObject> clouds;

    // PRIVATE FIELDS
    private Transform _playerTransform;
    private Transform _islandTransform;
    private Transform _cloudTransform;

    private int _score;
    private int _lives;

	// Use this for initialization
	void Start () {
        // Initialize Game Objects

        this.SetScore(0);
        this.SetLives(5);

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

    // GET and SET Methods
    public void SetScore(int score) {
        this._score = score;
        this.ScoreLabel.text = "SCORE: " + score;
    }

    public int GetScore() {
        return this._score;
    }

    public void SetLives(int lives) {
        this._lives = lives;
        this.LivesLabel.text = "LIVES: " + lives;
    }

    public int GetLives() {
        return this._lives;
    }
}
