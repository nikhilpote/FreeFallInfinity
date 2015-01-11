using UnityEngine;
using System.Collections;

public class SwipperController : MonoBehaviour {
	private static int objectKilled;
	void start() {
		objectKilled = 0;
	}
	void OnTriggerEnter2D(Collider2D otherObject) {
		if (otherObject.gameObject.transform.parent) {
						Destroy (otherObject.gameObject.transform.parent.gameObject);
				} else {
						Destroy(otherObject.gameObject);

				}
			
		SpawnScript.ObjCount = SpawnScript.ObjCount - 1;
		objectKilled++;

	}

	public static int objKilled
	{ 
		get { return objectKilled; }
		set { objectKilled = (int)value; }
		
	}
}
