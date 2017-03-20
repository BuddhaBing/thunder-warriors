using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {
	public Text healthDisplay;
	public Text moneyDisplay;
	public Text killCountText;

	private PlayerMoney money;
	private PlayerHealth health;
	private PlayerScore score;

	void Start(){
		var PlayerConfig = GetComponentInParent<PlayerConfig> ();
		money = PlayerConfig.money;
		health = PlayerConfig.health;
		score = PlayerConfig.score;
	}

	void Update(){
		UpdateMoneyUI (money.GetMoney());
		UpdateHealthUI (health.GetHealth());
		UpdateScoreUI (score.GetKillCount());
	}	
		
	public void UpdateMoneyUI(int money){
		moneyDisplay.text = "Money:" + money;
	}

	void UpdateHealthUI(int health) {
		healthDisplay.text = "Lives: " + health;
	}

	void UpdateScoreUI(int killCount) {
		killCountText.text = "Kills:" + killCount;
	}
}
