using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHelper : MonoBehaviour {

	private Animator anim;

	public void Initialize () {
		anim = GetComponentInChildren<Animator>();
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
		if (!anim) {return;}
		anim.SetTrigger (triggerWord);
	}

}
