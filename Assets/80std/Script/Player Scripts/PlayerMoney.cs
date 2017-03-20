using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoney : MonoBehaviour {
	public int money;

	public int GetMoney() {
		return money;
	}
	public void AddMoney(int moreMoney){
		money += moreMoney;
	}

	public void TakeMoney(int lessMoney){
		money -= lessMoney;
	}
}
