using UnityEngine;
using System.Collections;

public class HUDControl : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI()  {

		GUI.Label (new Rect (10, 10, 80, 20), "Score " + ScoreManager.getScore().ToString ());

	}


}
