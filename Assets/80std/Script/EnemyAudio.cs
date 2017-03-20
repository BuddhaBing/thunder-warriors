using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : MonoBehaviour {

	public AudioClip getHitClip;
	public float HitVolume= 1f;
	public AudioClip dieClip;
	public float dieVolume= 1f;
	public AudioClip breachClip;
	public float breachVolume= 1f;
	private AudioSource source;

	void Awake() {
		source = GetComponent<AudioSource>();
	}

	public void PlayHitAudio() {
		source.PlayOneShot (getHitClip, HitVolume);
	}

	public void PlayDieAudio() {
		source.PlayOneShot (dieClip, dieVolume);
	}

}
