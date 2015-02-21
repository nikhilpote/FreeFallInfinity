using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		GUI.Label (new Rect (Screen.width / 2 - 30, 20, 200, 20), "Score " + PlayerPrefs.GetInt (Constants.SCORE).ToString ());
		GUI.Label (new Rect (Screen.width / 2 - 30, 30, 200, 20), "Coins " + PlayerPrefs.GetInt (Constants.COIN).ToString ());

		System.Collections.Generic.List<string> listPowerupAvailable = UpdateManager.Instance.getItemstoUpgrade();
		int y = 150;
		foreach (string item in listPowerupAvailable) {
			Debug.Log("Items available are "+item);
			if (GUI.Button (new Rect (10,y, 200, 50), item)) {
				UpdateManager.Instance.upgradePowerUp(item);
			}
			y=y+50;
		}
		if (GUI.Button (new Rect (Screen.width / 2 - 40,70, 200, 60), "Retry?")) {
			Application.LoadLevel("GameScene");
			new ResetGame();
		}
	}
}
