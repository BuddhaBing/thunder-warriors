using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

	ConstructionManager constructionManager;

	void Start () 
	{
		constructionManager = ConstructionManager.instance;
	}
	
	public void PurchaseGunTurret_1 ()
	{
		constructionManager.SetTurretToBuild (constructionManager.gunTurret_1); 
	}
}
