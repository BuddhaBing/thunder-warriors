// Responsibility: Interface between shop and turretNode, has knowledge of selected turret
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BuildingManager : MonoBehaviour {

	public static BuildingManager instance;
	private BuildingWorker worker;

	public TurretNode nodeToBuildOn;

	private PlayerMoney playerMoney;

	public TurretUI turretUI;

	private GameObject turretToBuild;
	private GameObject turretToModify;

	void Awake ()
	{
		instance = this;
		worker = GetComponent<BuildingWorker> ();
		playerMoney = GetComponent<PlayerConfig>().money;
	}

	void Update() {
		if ( CanBuildTurret () ) { 
			StartBuild ();
		}
		TryShowUI ();
	}

	void TryShowUI(){
		if (turretToModify) {
			turretUI.ToggleUI (true);
		} else {
			turretUI.ToggleUI (false);
		}
	}

	public GameObject GetTurretToBuild()
	{
		return turretToBuild;
	}

	public GameObject GetTurretToModify()
	{
		return turretToModify;
	}

	public void SetTurretToBuild(GameObject turret)
	{
		turretToBuild = turret;
	}

	public void SetTurretToModify(GameObject turret)
	{
		turretToModify = turret;
	}
		
	public void SelectTurretNode(TurretNode node) {
		nodeToBuildOn = node;
	}

	bool CanBuildTurret() {
		if (!nodeToBuildOn) {return false;}
		if (!nodeToBuildOn.IsBuildable() ) {return false;}
		if (!turretToBuild) {return false;}
		if (!playerMoney.CanAffordTurret(turretToBuild) ) {return false;}
		return true;
	}

	bool CanUpgradeTurret() {
		if (!turretToModify.GetComponent<TurretConfig>().upgradePrefab) {return false;}
		return true;
	}

	void StartBuild() {
		playerMoney.TakeMoneyTurret (turretToBuild);
		worker.BuildTurret (nodeToBuildOn, turretToBuild);
	}

	public void StartUpgrade() {
		if (CanUpgradeTurret()) {
			var upgrade = turretToModify.GetComponent<TurretConfig>().upgradePrefab;
			var cost = turretToModify.GetComponent<TurretConfig> ().costToUpgrade;
			playerMoney.TakeMoney (cost);
			worker.UpgradeTurret (nodeToBuildOn, upgrade);
		}
	}

	public void SellTurret(){
		playerMoney.AddMoney (turretToModify.GetComponent<TurretConfig> ().sellPrice);
		worker.SellTurret(nodeToBuildOn,turretToModify);
	}
}
