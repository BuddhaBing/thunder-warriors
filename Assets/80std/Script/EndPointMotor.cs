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
		//if(Array.IndexOf (MyEnemyManager.All (), Enemy) == -1){return;}
		//call player to remove n lives
		GameObject.Destroy(Enemy);
	}
}