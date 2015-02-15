using UnityEngine;
using System.Collections;

public class SwipperController : MonoBehaviour {

	void start() {

	}
	void OnTriggerEnter2D(Collider2D otherObject) {
		string objectTag = otherObject.tag;
		if (otherObject.gameObject.transform.parent) {
						
						Destroy (otherObject.gameObject.transform.parent.gameObject);
				} else {
						Destroy(otherObject.gameObject);

				}
		if (objectTag == Constants.OBSTACLE) {
			SpawnScript.ObjCount = SpawnScript.ObjCount - 1;
		}
		//Debug.Log ("Obj Count is" + SpawnScript.ObjCount);
		if (otherObject.gameObject.tag == Constants.OBSTACLE) {
			ScoreManager.increaseScore ();
		}

	}


}
