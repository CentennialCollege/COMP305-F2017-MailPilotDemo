using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    // FIELDS
    public GameObject Cloud;
    public int cloudNumber;

    public List<GameObject> clouds;


	// Use this for initialization
	void Start () {
        this.clouds = new List<GameObject>();
        for (int count = 0; count < this.cloudNumber; count++)
        {
            this.clouds.Add(Instantiate(Cloud));
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
