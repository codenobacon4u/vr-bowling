using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV : MonoBehaviour {

	public Camera mCamera;
	public int size = 720, depth = 30;

	// Use this for initialization
	void Start () {
		mCamera.targetTexture = new RenderTexture(size, size, depth);
		mCamera.targetTexture.isPowerOfTwo = true;
		mCamera.targetTexture.Create();
		GetComponent<Renderer>().material.mainTexture = mCamera.targetTexture;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
