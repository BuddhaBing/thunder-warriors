
using UnityEngine;
using System.Collections;

public class BuildingWorker : MonoBehaviour
{
	private BuildingManager manager;
	private PlayerConfig playerConfig;
	private EnemyManager enemyManager;

	void Start () {
		manager = GetComponent<BuildingManager>();
		playerConfig = GetComponent<PlayerConfig> ();
		enemyManager = playerConfig.enemyManager;
	}

	public void BuildTurret (TurretNode node, GameObject turret)
	{
		var instance = Instantiate (turret, node.transform.position + node.positionOffset, node.transform.rotation);
		instance.GetComponent<TurretConfig> ().enemies = enemyManager;
		instance.transform.SetParent (node.gameObject.transform);
		node.SetOccupied(true);
		manager.nodeToBuildOn = null;
	}
		
	public void UpgradeTurret (TurretNode node, GameObject turret)
	{
		Destroy (node.GetTurret());
		var instance = Instantiate (turret, node.transform.position + node.positionOffset, node.transform.rotation);
		instance.GetComponent<TurretConfig> ().enemies = enemyManager;
		instance.transform.SetParent (node.gameObject.transform);
		node.SetOccupied(true);
		manager.SetTurretToModify (instance);
	}

	public void SellTurret (TurretNode node, GameObject turret) { // Model or Turret Construction? 
		Destroy (turret);
		node.SetOccupied (false);
		manager.nodeToBuildOn = null;
		manager.SetTurretToModify(null);
	}
}

