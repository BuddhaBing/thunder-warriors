using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {
	public float health;
	public Image healthBar;
	public PlayerConfig OwningPlayer;

	private float maxHealth;
	private EnemyValue enemyVal;
	private EnemyAnimation anim;
	private EnemyAudio sfx;

	void OnEnable(){maxHealth = health;}

	void Start() {
		enemyVal = GetComponent<EnemyValue> ();
		anim = this.transform.GetComponent<EnemyAnimation>();
		sfx = this.transform.GetComponent<EnemyAudio>();
	}

	public void TakeDamage(int damage){
		if (sfx) {sfx.PlayHitAudio();}
		health -= damage;
		UpdateUi ();
		CheckDead();
	}

	void CheckDead(){
		if (health >= 1) {
			anim.PlayAnimation ("hit");
		} else {
			Die ();
		}
	}

	void Die() {
		if (anim) {anim.PlayAnimation ("dead");}
		if (sfx) {sfx.PlayDieAudio();}
		Destroy(gameObject, 3f);
		GetComponent<EnemyMovementController> ().Speed = 0;
	}

	void UpdateUi()
	{
		healthBar.fillAmount = health / maxHealth;
	}

	void OnDestroy(){
		if (health > 0) {return;}  // so we don't give money if we reach the end
		enemyVal.GiveMoneyToPlayer ();
		OwningPlayer.score.AssignKill (); // TODO: check killing player was owning player( might want this in future)
	}
}
