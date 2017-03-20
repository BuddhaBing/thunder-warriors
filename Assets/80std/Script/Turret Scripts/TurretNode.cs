using UnityEngine.EventSystems;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Responsibility: Builds + owns selected turret

public class TurretNode : MonoBehaviour {

	public Color hoverColor;
	public GameObject owner;

	private Renderer rend;
	private Color startColor;
	private ConstructionManager constructionManager;
	private bool IsFull = false;

	private Coroutine pulser;
	private bool pulsing;
	private float pulseDuration = 0.5f;
	private float smoothness = 0.02f;

	private GameObject residentTurret;

	private Vector3 positionOffset = new Vector3(0f, 0.15f, 0f);

	private EnemyManager enemyManager;
	private PlayerMoney playerMoney;

	void Start () {
		rend = GetComponent<Renderer> ();
		startColor = rend.material.color;
		enemyManager = owner.transform.FindChild ("EnemyManager").gameObject.GetComponent<EnemyManager> ();
		constructionManager = ConstructionManager.instance;
		playerMoney = owner.GetComponent<PlayerConfig>().money;
	}

	void Update() {
		if (constructionManager.GetTarget () != this || !constructionManager.IsUpgradeMode ()) {
			if(pulsing) { StopPulsing (); }
			return;
		} 
		if(!pulsing) { pulser = StartCoroutine(LerpColor()); }
	}

	void OnMouseEnter()
	{
		if (constructionManager.GetTurretToBuild() == null) {return;}
		rend.material.color = hoverColor;
	}

	void OnMouseExit()
	{
		rend.material.color = startColor;
	}

	void OnMouseDown()
	{
		if (IsFull) {
			constructionManager.SelectTurretNode (this);
		}
		if (constructionManager.GetTurretToBuild () == null) { return; }
		BuildTurret ();
	}

	void BuildTurret()
	{
		residentTurret = constructionManager.GetTurretToBuild ();
		int cost = residentTurret.GetComponent<TurretCost> ().costToBuy;

		if(cost > playerMoney.GetMoney()) {return;}

		residentTurret = Instantiate (residentTurret, transform.position + positionOffset, transform.rotation);

		FinaliseBuild (cost);
	}

	public void UpgradeTurret()
	{
		if (residentTurret.GetComponent<TurretCost> ().upgradePrefab != null) {
			int cost = residentTurret.GetComponent<TurretCost> ().costToUpgrade;
			GameObject upgradePrefab = residentTurret.GetComponent<TurretCost> ().upgradePrefab;

			if(cost > playerMoney.GetMoney()) {return;}

			Destroy (residentTurret);
			residentTurret = Instantiate (upgradePrefab, transform.position + positionOffset, transform.rotation);

			FinaliseBuild (cost);
		}
	}

	void FinaliseBuild(int cost)
	{
		residentTurret.GetComponent<Turret> ().enemyManager = enemyManager;
		residentTurret.GetComponent<Turret>().SetOwner (owner);
		residentTurret.transform.SetParent (gameObject.transform);
		IsFull = true;
		playerMoney.TakeMoney (cost);
	}

	void StopPulsing() {
		StopCoroutine (pulser);
		rend.material.color = startColor;
		pulsing = false;
	}

	private IEnumerator LerpColor()
	{
		float progress = 0f;
		float increment = smoothness/pulseDuration;
		while(progress < 1)
		{
			pulsing = true;
			rend.material.color = Color.Lerp(Color.green, startColor, progress);
			progress += increment;
			yield return new WaitForSeconds(smoothness);
		}
		pulsing = false;
	}

	public void SellTurret () {
		playerMoney.AddMoney (residentTurret.GetComponent<TurretCost> ().sellPrice);
		Destroy (residentTurret);
		constructionManager.UpgradeModeOff ();
		residentTurret = null;
	}
}
