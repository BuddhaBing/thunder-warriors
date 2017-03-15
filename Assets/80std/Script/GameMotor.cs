using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMotor : MonoBehaviour {
	public static PlayerMotor[] players;
	void Awake (){
		players = new PlayerMotor[transform.childCount];
		for (int i = 0; i < players.Length; i++) {
			players [i] = transform.GetChild (i).GetComponent<PlayerMotor> ();
		}
	}	

}
