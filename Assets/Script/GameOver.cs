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
		GUI.Label (new Rect (Screen.width / 2 - 30, 20, 200, 20), "Score " + PlayerPrefs.GetInt ("score").ToString ());
		if (GUI.Button (new Rect (Screen.width / 2 - 40,70, 80, 20), "Retry?")) {
			Application.LoadLevel(0);
			SwipperController.objKilled = 0;
		}
	}
}
