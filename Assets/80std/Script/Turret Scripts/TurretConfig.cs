using UnityEngine;
using System.Collections;

public class TurretConfig : MonoBehaviour
{

	[Header("Attributes")]
	public string enemyTag = "Enemy";
	public float range = 3f;
	public float turnSpeed = 10f;
	public float fireRate = 2f;
	public float updateRate = 0.5f;
	public int costToBuy;
	public int costToUpgrade;
	public GameObject upgradePrefab;
	public int sellPrice;
	public GameObject bulletPrefab;

	private Transform target;
	private float shortestDistance;
	private GameObject nearestEnemy;
		
	[Header("Unity Setup Fields")]
	public Transform partToRotate;
	public Transform[] firepoints;
	public EnemyManager enemies;
	public GameObject owner;

	[Header("Model View Controller")]
	public TurretModel model;
	public TurretTargeting targeting;
	public TurretView view;

	void Awake () {
		model = GetComponent<TurretModel>();
		targeting = GetComponent<TurretTargeting>();
		view = GetComponent<TurretView>();
	}

}

