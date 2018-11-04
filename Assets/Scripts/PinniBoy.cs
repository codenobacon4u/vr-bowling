using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinniBoy : MonoBehaviour {

    public bool hasFallen = false;
	AudioSource s;

	private void Start()
	{
		s = GetComponent<AudioSource>();
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Ball"))
		{
			s.Play();
		}
	}
}
