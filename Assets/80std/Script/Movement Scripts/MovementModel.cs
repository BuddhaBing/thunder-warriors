using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementModel : MonoBehaviour {

	public Vector3 TargetDir (Vector3 target, Vector3 enemy)
    {
        return target - enemy;
    }

    public float NormaliseSpeed (float speed, float time)
    {
        return speed * time;
    }


}
