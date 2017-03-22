using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretUI : MonoBehaviour {

	private TurretNode currentTarget;
	public BuildingManager buildingManager;

	public void SetTarget(TurretNode target) {
		currentTarget = target;
		ToggleUI (true);
	}

	public TurretNode GetTarget() {
		return currentTarget;
	}

	public void ToggleUI(bool status) {
		gameObject.SetActive(status);
	}

	public void Upgrade() {
		buildingManager.StartUpgrade ();
	}

	public void Sell() { 
		buildingManager.SellTurret ();
	}

}
