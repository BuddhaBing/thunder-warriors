using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyPrefabConfig : MonoBehaviour {
	[Header ("DO NOT TOUCH, will get overridden")]

	[Header("Attributes")]
	public string enemyName;
	public float speed = 4f;
	public float rotationSpeed = 10f;
	public int onKillMoney;
	public float maxHealth;

	[Header("Audio")]
	public AudioClip getHitClip;
	public float getHitVolume= 1f;
	public AudioClip dieClip;
	public float dieVolume= 1f;
	public AudioClip breachClip;
	public float breachVolume= 1f;

	[Header("Unity Setup Fields")]
	public GameObject prefab;
	public GameObject modelBody;
	public WaypointManager waypointManager;
	public Image healthBar;
	public PlayerConfig owningPlayer;

	[Header("Enemy")]
	public EnemyModel enemyModel;
	public EnemyController enemyController;
	public EnemyView enemyView;
	public EnemyConfig enemyScriptableObject;

	[Header("Movement")]
	public MovementModel movementModel;
	public MovementController movementController;
	public MovementView movementView;

	[Header("Helpers")]
	public AudioHelper sfx;
	public AnimationHelper anim;

	void Awake() {
		waypointManager = GetComponent<WaypointManager> ();
		owningPlayer = GetComponent<PlayerConfig> ();

		enemyModel = GetComponent<EnemyModel> ();
		enemyController = GetComponent<EnemyController> ();
		enemyView = GetComponent<EnemyView> ();

		movementModel = GetComponent<MovementModel> ();
		movementController = GetComponent<MovementController> ();
		movementView = GetComponent<MovementView> ();

		sfx = GetComponent<AudioHelper> ();
		anim = GetComponent<AnimationHelper> ();
	}

	public void Initialize() {
		SetEnemyValues ();
		SetEnemySounds ();
		SetEnemyModel  ();

		movementController.Initialize ();
		sfx.Initialize ();
		anim.Initialize ();
	}

	void SetEnemyValues() {
		enemyName = enemyScriptableObject.enemyName;
		speed = enemyScriptableObject.speed;
		rotationSpeed = enemyScriptableObject.rotationSpeed;
		onKillMoney = enemyScriptableObject.onKillMoney;
		maxHealth = enemyScriptableObject.maxHealth;
	}

	void SetEnemySounds() {
		getHitClip = enemyScriptableObject.getHitClip;
		getHitVolume = enemyScriptableObject.getHitVolume;
		dieClip = enemyScriptableObject.dieClip;
		dieVolume = enemyScriptableObject.dieVolume;
		breachClip = enemyScriptableObject.breachClip;
		breachVolume = enemyScriptableObject.breachVolume;
	}

	void SetEnemyModel() {
		prefab = enemyScriptableObject.prefab;
		modelBody = GameObject.Instantiate (prefab, transform.position, transform.rotation);
		modelBody.transform.SetParent (transform);
	}
}


