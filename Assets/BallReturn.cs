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
		if (other.gameObject.CompareTag("Ball"))
		{
			Destroy(other.gameObject);
			gameManager.GetComponent<GameManager>().Roll();
		}
	}
}
