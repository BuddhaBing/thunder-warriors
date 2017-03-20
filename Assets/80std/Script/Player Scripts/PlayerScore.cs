using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour {

	private int kills = 0;

	public int GetKillCount() {
		return kills;
	}

	public void AssignKill() {
		kills++;
	}
}
