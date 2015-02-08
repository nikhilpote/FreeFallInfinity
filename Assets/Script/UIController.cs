using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	// Use this for initialization
	static	Text [] Texts;
	void Start () {
		Texts = gameObject.GetComponentsInChildren <Text> ();
		Debug.Log (Texts[0].text);
	}

	public static void setScore(int score) {
		Texts [0].text = "Score:"+score.ToString ();
	}
	public static void setCoins(int coins ) {
		Texts [1].text = "Coins:" + coins.ToString ();
	}
}
