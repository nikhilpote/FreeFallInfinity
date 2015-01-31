using UnityEngine;
using System.Collections;

public class SwipperController : MonoBehaviour {

	void start() {

	}
	void OnTriggerEnter2D(Collider2D otherObject) {
		if (otherObject.gameObject.transform.parent) {
						Destroy (otherObject.gameObject.transform.parent.gameObject);
				} else {
						Destroy(otherObject.gameObject);

				}
			
		SpawnScript.ObjCount = SpawnScript.ObjCount - 1;
		ScoreManager.increaseScore ();

	}


}
