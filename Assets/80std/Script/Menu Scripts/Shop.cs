using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

	public BuildingManager visitor;
	private ShopInventory inventory;
	private GameObject[] turrets;
	private GameObject selectedItem;

	void Start () 
	{
		inventory = GetComponent<ShopInventory>();
		turrets = inventory.turretPrefabs;
	}

	public void Select (int index)
	{
		visitor.SetBuildingStatus (true);
		visitor.SetTurretToBuild(turrets[index]);
	}

	public void Upgrade() {
		visitor.StartUpgrade ();
	}
}
