using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[CreateAssetMenu]
public class EnemyConfig : ScriptableObject {

	[Header("Attributes")]
	public string enemyName;
	public float speed = 4f;
	public float rotationSpeed = 10f;
	public int onKillMoney;
	public float maxHealth= 10f;

	[Header("Audio")]
	public AudioClip getHitClip;
	public float getHitVolume= 1f;
	public AudioClip dieClip;
	public float dieVolume= 1f;
	public AudioClip breachClip;
	public float breachVolume= 1f;

	[Header("Unity Setup Fields")]
	public GameObject prefab;
}


