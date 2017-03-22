using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyView : MonoBehaviour {

	private EnemyPrefabConfig config;
	private EnemyModel model;
	private PlayerConfig owningPlayer;

	private MovementController movementController;
	private AudioHelper sfx;
	private AnimationHelper anim;
	private Image healthBar;
	private int onKillMoney;

	void Start () {
		config = GetComponent<EnemyPrefabConfig> ();
		movementController = GetComponent<MovementController> ();

		owningPlayer = config.owningPlayer;
		sfx = config.sfx;
		anim = config.anim;
		model = config.enemyModel;
		healthBar = config.healthBar;
		onKillMoney = config.onKillMoney;
	}
	
	public void DeathSequence ()
	{
		UpdateHealthBar ();
		if (anim) {anim.PlayAnimation ("dead");}
		if (sfx) {sfx.PlayDieAudio();}

		owningPlayer.money.AddMoney(onKillMoney);
		movementController.StopObject ();
		Destroy(gameObject, 3f);
	}

	public void HitSequence ()
	{
		UpdateHealthBar ();
		if (anim) {anim.PlayAnimation ("hit");}
		if (sfx)  {sfx.PlayHitAudio ();}
	}

	public void UpdateHealthBar ()
	{
		healthBar.fillAmount = model.HealthRatio();
	}
}
