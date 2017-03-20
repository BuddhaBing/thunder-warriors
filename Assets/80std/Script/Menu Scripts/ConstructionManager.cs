using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Responsibility: Interface between shop and turretNode, has knowledge of selected turret

public class ConstructionManager : MonoBehaviour {

	public static ConstructionManager instance;

	public GameObject gunTurret_1;

	public TurretUI turretUI;

	private GameObject turretToBuild;
	private GameObject turretToUpgrade;

	void Awake ()
	{
//		turretToBuild = gunTurret_1; TODO, not have this wierd default
		if (instance != null)
		{
			Debug.LogError ("More than one ConstructionManager in scene!");
			return;
		}
		instance = this;
	}
		

	void Update() 
	{
		if(Input.GetMouseButtonDown(0) && !(Input.GetKey("left shift") || Input.GetKey("right shift")))
			SetTurretToBuild (null);
		if(Input.GetKeyUp ("left shift") || Input.GetKeyUp ("right shift"))
			SetTurretToBuild (null);
	}

	public GameObject GetTurretToBuild()
	{
		return turretToBuild;
	}

	public GameObject GetTurretToUpgrade()
	{
		return turretToUpgrade;
	}

	public void SetTurretToBuild(GameObject turret)
	{
		turretToBuild = turret;
		if (turret) { DeselectTurretNode (); }
	}

	public void SetTurretToUpgrade(GameObject turret)
	{
		turretToUpgrade = turret;
	}

	public void SelectTurretNode(TurretNode node) {
		turretToBuild = null;
		turretUI.SetTarget (node);
	}

	void DeselectTurretNode() {
		turretUI.ToggleUI (false);
	}

	public TurretNode GetTarget() {
		return turretUI.GetTarget();
	}

	public bool IsUpgradeMode() {
		return turretUI.gameObject.activeInHierarchy;
	}

	public void UpgradeModeOff() {
		turretUI.ToggleUI(false);
	}
}
