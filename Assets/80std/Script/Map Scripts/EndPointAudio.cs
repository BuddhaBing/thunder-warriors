using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPointAudio : MonoBehaviour {

	public AudioClip breachClip;

	private AudioSource source;

	void Awake() {
		source = GetComponent<AudioSource>();
	}
		
	public void PlayBreachAudio() {
		source.PlayOneShot (breachClip, 1f);
	}
}
