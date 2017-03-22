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

	public bool CanAfford(int cost) {
		return money >= cost;
	}

	public bool CanAffordTurret(GameObject turret) {
		var cost = turret.GetComponent<TurretConfig>().costToBuy;
		return money >= cost;
	}

	public void TakeMoneyTurret(GameObject turret) {
		var cost = turret.GetComponent<TurretConfig>().costToBuy;
		money -= cost;
	}
}
