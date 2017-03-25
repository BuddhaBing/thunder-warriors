// Responsibility: Interface between shop and turretNode, has knowledge of selected turret
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BuildingManager : MonoBehaviour {

	public static BuildingManager instance;
	private BuildingWorker worker;
	private bool building;

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
		if (!building) return;
		if ( CanBuildTurret () ) { 
			StartBuild ();
		}
		TryShowUI ();
	}

	void TryShowUI(){
		if (!nodeToBuildOn || (nodeToBuildOn && nodeToBuildOn.transform.childCount == 0)) { 
			turretUI.ToggleUI (false);
		}
		else { 
			turretUI.ToggleUI (true);
		}
	}

	public GameObject GetTurretToBuild()
	{
		return turretToBuild;
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
		turretToModify = nodeToBuildOn.GetTurret ();
		if (!turretToModify.GetComponent<TurretConfig>().upgradePrefab) {return false;}
		return true;
	}

	void StartBuild() {
		playerMoney.TakeMoneyTurret (turretToBuild);
		worker.BuildTurret (nodeToBuildOn, turretToBuild);
		FinaliseBuild ();
	}

	public void SetBuildingStatus(bool status) {
		building = status;
	}

	void FinaliseBuild() {
		SetBuildingStatus (false);
		SetTurretToBuild (null);
	}

	public void StartUpgrade() {
		if (CanUpgradeTurret()) {
			var upgrade = turretToModify.GetComponent<TurretConfig>().upgradePrefab;
			var cost = turretToModify.GetComponent<TurretConfig> ().costToUpgrade;
			playerMoney.TakeMoney (cost);
			worker.UpgradeTurret (nodeToBuildOn, upgrade);
			FinaliseBuild ();
		}
	}

	public void SellTurret(){
		var turret = nodeToBuildOn.GetTurret ();
		playerMoney.AddMoney (turret.GetComponent<TurretConfig> ().sellPrice);
		worker.SellTurret(nodeToBuildOn, turret);
	}
}
