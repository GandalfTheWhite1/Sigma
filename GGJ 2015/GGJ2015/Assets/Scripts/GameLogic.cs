using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour {

	private bool gameOver;
	private bool restart;
	private int score;

	// Use this for initialization
	void Start () {
		gameOver = false;
		restart = false;
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

// TODO: Change Circle Collider Bullet Destroyer radius