﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollyBoi : MonoBehaviour {
   

    public Vector3 force;
	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update () {
		if (Input.GetButtonDown("Fire1"))
		{
      
            rb.AddForce(force);
		}
	}
   

}
