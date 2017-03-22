using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {
	public Text healthDisplay;
	public Text moneyDisplay;
	public Text killCountText;
	public Text winText;

	public string winString = "Level Complete" ;
	public string lossString  = "You lose" ;

	private PlayerMoney money;
	private PlayerHealth health;
	private PlayerScore score;
	private PlayerState state;

	void Start(){
		var playerConfig = GetComponent<PlayerConfig> ();

		money = playerConfig.money;
		health = playerConfig.health;
		score = playerConfig.score;
		state = playerConfig.state;
	}

	public void MyUpdate(){
		UpdateMoney (money.GetMoney());
		UpdateHealth (health.GetHealth());
		UpdateScore (score.GetKillCount());
		UpdateStateText (state.GetState ());
	}	
		
	public void UpdateMoney(int money){
		moneyDisplay.text = "Money:" + money;
	}

	void UpdateHealth(int health) {
		healthDisplay.text = "Lives: " + health;
	}

	void UpdateScore(int killCount) {
		killCountText.text = "Kills:" + killCount;
	}

	void UpdateStateText(int WinEnumerator){
		switch (WinEnumerator) {
		case -1:
			winText.text = "";
			break;
		case 0:
			winText.text = winString;
			break;
		case 1:
			winText.text = lossString;
			break;
		default:
			winText.text = "unknown case passed to updatewintext";
			break;	
		}
	}
}
