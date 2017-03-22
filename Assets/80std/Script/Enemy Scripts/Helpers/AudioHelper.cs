using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHelper : MonoBehaviour {


	private AudioClip getHitClip;
	private float getHitVolume;
	private AudioClip dieClip;
	private float dieVolume;

	private AudioSource source;

	void Awake() {
		source = GetComponent<AudioSource>();
	}

	public void Initialize(){
		var config = GetComponent<EnemyPrefabConfig> ();
		getHitClip   = config.getHitClip;
		getHitVolume = config.getHitVolume;
		dieClip   = config.dieClip;
		dieVolume = config.dieVolume;
	}

	public void PlayHitAudio() {
		source.PlayOneShot (getHitClip, getHitVolume);
	}

	public void PlayDieAudio() {
		source.PlayOneShot (dieClip, dieVolume);
	}

}
