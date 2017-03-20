using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour {
	public static PlayerConfig[] All;

	void Awake (){
		All = new PlayerConfig[transform.childCount];
		for (int i = 0; i < All.Length; i++) {
			All [i] = transform.GetChild (i).GetComponent<PlayerConfig> ();
		}
	}

}
