using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPointMotor : MonoBehaviour {
	private EndPointLogic EndPointLogic = new EndPointLogic();

	void OnEnable(){
		EndPointLogic.MyMotor = this;
	}

	void OnTriggerEnter(Collider collider){
		EndPointLogic.EnemyLeaked (collider.gameObject);
	}

	public void DestroyItem(GameObject obj){
		GameObject.Destroy (obj);
	}
}

public class EndPointLogic{
	public EndPointMotor MyMotor;

	public void EnemyLeaked(GameObject Enemy){
		if (Enemy.tag != "Enemy") {return;}
		GameObject.Destroy(Enemy);
		//Hurt player
	}
}