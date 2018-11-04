using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollyBoi : MonoBehaviour {
   

    public Vector3 force;
	public bool debug = false;
	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update () {
		if (OVRInput.GetDown(OVRInput.Button.One) && debug)
		{
            rb.AddForce(force);
		}
	}
   

}
