using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReturn : MonoBehaviour {
	public GameObject gameManager;
	public float wait = 2f;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Ball"))
		{
			Destroy(other.gameObject);
			gameManager.GetComponent<GameManager>().Roll();
		}
	}
}
