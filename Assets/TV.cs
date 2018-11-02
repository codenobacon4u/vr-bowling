using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV : MonoBehaviour {

	public Camera camera;
	public int size = 720, depth = 30;

	// Use this for initialization
	void Start () {
		camera.targetTexture = new RenderTexture(size, size, depth);
		camera.targetTexture.isPowerOfTwo = true;
		camera.targetTexture.Create();
		GetComponent<Renderer>().material.mainTexture = camera.targetTexture;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
