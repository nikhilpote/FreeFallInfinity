using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class UpdateManager {

	static UpdateManager instance=null;
	static readonly object padlock = new object();
	private JSONObject objectPowerups;
	private JSONObject objectCoinsperPowerups;
	System.Collections.Generic.List<string> listPowerups;
	
	UpdateManager()
	{
		TextAsset jsonfile = Resources.Load (Constants.UPDATEJSONFILE) as TextAsset;
		JSONObject jsonObjects = new JSONObject (jsonfile.text);

		objectPowerups = (JSONObject)jsonObjects.list [0];
		objectCoinsperPowerups = (JSONObject)jsonObjects.list [1];
		setupPowerupLevels ();

	}
	
	public static UpdateManager Instance
	{
		get
		{
			lock (padlock)
			{
				if (instance==null)
				{
					instance = new UpdateManager();
				}
				return instance;
			}
		}
	}

	private void setupPowerupLevels() {
	 listPowerups = new System.Collections.Generic.List<string> (new string[] {
						Constants.COINDOUBLER,
						Constants.MAGNET,
						Constants.FLYING_HELMET,
						Constants.ROCKET,
						Constants.SHEILD,
						Constants.SPEED_SLOWER,
						Constants.CANON_RIDE,
						Constants.PARACHUTE_HEALTH_INCREMENT,
						Constants.PARACHUTE_HEALTH_DECREMENT
				});
		foreach (string powerup in listPowerups) {

			if(!PlayerPrefs.HasKey(powerup+PersistentStore.LEVEL)) {
				Debug.Log("Inside Playerprefs");
				PlayerPrefs.SetInt(powerup+PersistentStore.LEVEL,0);
			}
		}
		if (!PlayerPrefs.HasKey (Constants.COIN)) {
			PlayerPrefs.SetInt(Constants.COIN,0);
		}
	}

	public float getCurrentValueforUpgrade(string key) {
		JSONObject arrayIntervals = objectPowerups.GetField (key);
		int currentLevel = PlayerPrefs.GetInt (key+PersistentStore.LEVEL);
		//JSONObject objectLevel =  arra [currentLevel];
		string value = arrayIntervals [currentLevel].str;
		return float.Parse (value);
	}

	private bool isUpdateAvailableforPowerup(string powerUp) {
		int currentCoins = PlayerPrefs.GetInt (Constants.COIN);
		int currentLevel = PlayerPrefs.GetInt (powerUp + PersistentStore.LEVEL);
		JSONObject arrayCoins = objectCoinsperPowerups.GetField (powerUp);
		if (currentLevel+1 < Constants.MAX_LEVEL) {
			string value = arrayCoins[currentLevel+1].str;
			int nextLevelCoins = int.Parse(value) ;
			if(currentCoins>=nextLevelCoins) {
				return true;
			}
		}
		return false;
	}

	public List<string> getItemstoUpgrade() {
		List<string> listPowerupAvailable = new List<string> ();
		foreach (string powerup in listPowerups) {
			if(isUpdateAvailableforPowerup(powerup)) {
				listPowerupAvailable.Add(powerup);
			}
		}
		return listPowerupAvailable;
	}

	public void upgradePowerUp (string powerUp) {
		int currentLevel = PlayerPrefs.GetInt (powerUp + PersistentStore.LEVEL);
		JSONObject arrayCoins = objectCoinsperPowerups.GetField (powerUp);
		int coinAvailable = PlayerPrefs.GetInt(Constants.COIN)- int.Parse (arrayCoins [currentLevel + 1].str);
		PlayerPrefs.SetInt (Constants.COIN, coinAvailable);
		PlayerPrefs.SetInt (powerUp + PersistentStore.LEVEL, currentLevel + 1);
	}

	public void setPlayerPrefs(pickable.PickableManager managerPickable) {
		PlayerPrefs.SetInt (Constants.SCORE, (int)ScoreManager.getScore());
		PlayerPrefs.SetInt (Constants.COIN, (PlayerPrefs.GetInt(Constants.COIN)+(int)managerPickable.getCountForItem (Constants.COIN)));

	}

	void accessData(JSONObject obj){
		switch(obj.type){
		case JSONObject.Type.OBJECT:
			for(int i = 0; i < obj.list.Count; i++){
				string key = (string)obj.keys[i];
				JSONObject j = (JSONObject)obj.list[i];
				Debug.Log(key);
				accessData(j);
			}
			break;
		case JSONObject.Type.ARRAY:
			foreach(JSONObject j in obj.list){
				accessData(j);
			}
			break;
		case JSONObject.Type.STRING:
			Debug.Log(obj.str);
			break;
		case JSONObject.Type.NUMBER:
			Debug.Log(obj.n);
			break;
		case JSONObject.Type.BOOL:
			Debug.Log(obj.b);
			break;
		case JSONObject.Type.NULL:
			Debug.Log("NULL");
			break;
			
		}
	}
}
