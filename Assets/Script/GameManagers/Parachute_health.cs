using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Parachute_health : MonoBehaviour {

	public  Scrollbar healthBar;

	void Start() {
		this.healthBar = gameObject.GetComponent<Scrollbar> ();
	}
	// Use this for initialization

	public  void changeSize(float size) {
		this.healthBar.size = size;
	}

	public  void decrementScrollSize() {
		if (this.healthBar.size <= 0) {
			Player.AccelController.setHealthZero(true);
		} else {
			this.healthBar.size = this.healthBar.size - Constants.DEFAULT_PARACHUTE_SIZE_DELTA_DECREMENT;
		}
	}

	public  void incrementScrollSize() {
		Debug.Log ("incrementScrollSize");
		if (this.healthBar.size <= 1.0f) {
			this.healthBar.size = this.healthBar.size + Constants.DEFAULT_PARACHUTE_SIZE_DELTA_INCREMENT;
			Player.AccelController.setHealthZero(false);
		}
	}
}
