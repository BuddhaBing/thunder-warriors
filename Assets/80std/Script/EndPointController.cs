// Probably better to add collision boxes and check them than this mess.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPointMotor : MonoBehaviour {
    private EndPointLogic EndPointLogic = new EndPointLogic();

    void OnTriggerEnter(Collider collider){
        EndPointLogic.EnemyLeaked (collider.gameObject);
    }
}

public class EndPointLogic{
    public EnemyManager MyEnemyManager;

    public void EnemyLeaked(GameObject Enemy){
        //if(Array.IndexOf (MyEnemyManager.All (), Enemy) == -1){return;}
        //call player to remove n lives
        GameObject.DestroyImmediate (Enemy);
    }
}
