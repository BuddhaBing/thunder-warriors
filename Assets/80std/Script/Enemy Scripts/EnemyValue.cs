using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyValue : MonoBehaviour {

	public int onKillMoney;
	private PlayerMoney playerMoney;

	void Start(){
		playerMoney = gameObject.transform.parent.GetComponentInParent<PlayerMoney> ();
	}

	public void GiveMoneyToPlayer(){
		playerMoney.AddMoney(onKillMoney);
	}

}
