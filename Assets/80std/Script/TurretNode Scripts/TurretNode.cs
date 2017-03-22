using UnityEngine.EventSystems;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurretNode : MonoBehaviour {

	private bool occupied;
	public GameObject owner;
	public BuildingManager buildingManager;
	public Vector3 positionOffset = new Vector3(0f, 0.15f, 0f);

	void Awake () {
		owner = transform.parent.parent.gameObject;
		var playerConfig = owner.GetComponent<PlayerConfig> ();
		buildingManager = playerConfig.buildingManager;
	}

	public bool IsBuildable() {
		return !occupied;
	}

	public void SetOccupied(bool status) {
		occupied = status;
	}

	public void StartBuild() {
		buildingManager.SelectTurretNode (this);
	}

	public void ModifyChild(){
		buildingManager.SetTurretToModify (GetTurret());
		StartBuild ();
	}

	public GameObject GetTurret() {
		return transform.GetChild(0).gameObject;
	}
		
}
