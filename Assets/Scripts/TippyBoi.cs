using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class TippyBoi : MonoBehaviour {

    public AudioSource impact;
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

	private void OnTriggerEnter(Collider other)
	{
        
        if (other.tag == "Floor")
		{
            impact.Play();
            Destroy(transform.parent.gameObject, 1f);
            transform.parent.gameObject.GetComponent<PinniBoy>().hasFallen = true;
        }
	}
}
