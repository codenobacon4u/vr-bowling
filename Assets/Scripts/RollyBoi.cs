using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RollyBoi : MonoBehaviour {

	public bool debug = false;
	public Vector3 force;
	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update () {
		if ((Input.GetButtonDown("Fire1") || OVRInput.GetDown(OVRInput.Button.One)) && debug)
		{
            rb.AddForce(force);
		}
	}
}

[CustomEditor(typeof(RollyBoi))]
public class RollyBioEditor : Editor
{
	public override void OnInspectorGUI()
	{
		RollyBoi comp = target as RollyBoi;
		comp.debug = GUILayout.Toggle(comp.debug, "Debug");
		if (comp.debug) comp.force = EditorGUILayout.Vector3Field("Force:", comp.force);
	}
}
