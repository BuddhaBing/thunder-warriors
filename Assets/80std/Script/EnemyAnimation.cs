using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour {

	private Animator anim;

	void Start () {
		anim = GetComponent<Animator>();
		PlayAnimation ("run");
	}

	void Update () {
		if (!IsAnimatorPlaying ()) {
			PlayAnimation ("run");
		}
	}

	bool IsAnimatorPlaying() {
		return anim.GetCurrentAnimatorStateInfo(0).length > anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
	}

	public void PlayAnimation(string triggerWord) {
		var anim = GetComponent<Animator>();
		if (!anim) {return;}
		anim.SetTrigger (triggerWord);
	}

}
