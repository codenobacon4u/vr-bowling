using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReturn : MonoBehaviour {
	public GameObject gameManager;
	public float wait = 2f;
	private GameObject ball;
	// Use this for initialization
	void Start () {
		ball = GameObject.FindGameObjectWithTag("Ball");
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.Equals(ball))
		{
			StartCoroutine(gameManager.GetComponent<GameManager>().CountPins());
		}
	}
}
