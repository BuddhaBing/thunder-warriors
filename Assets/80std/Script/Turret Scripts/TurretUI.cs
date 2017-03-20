using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretUI : MonoBehaviour {

	private TurretNode currentTarget;
	ConstructionManager constructionManager;

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
		currentTarget.UpgradeTurret ();
	}

	public void Sell() {
		currentTarget.SellTurret ();
	}

}
