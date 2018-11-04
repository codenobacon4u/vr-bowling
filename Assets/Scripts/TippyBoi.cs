using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class TippyBoi : MonoBehaviour {

    public AudioSource impact;
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponentInParent<AudioSource>();
    }

	private void OnTriggerEnter(Collider other)
	{
        
        if (other.tag == "Floor")
		{
            audioSource.Play();
            Destroy(transform.parent.gameObject, 4f);
            transform.parent.gameObject.GetComponent<PinniBoy>().hasFallen = true;
        }
	}
}
