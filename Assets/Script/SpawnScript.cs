using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

	// Use this for initialization
	public GameObject[] obj;
	public GameObject[] pickables;
	public GameObject player;
	public float spawnmin = 1.0f;
	public float spawnmax = 2.0f;
	private static int ObjectCount;
	public float tileheight;
	private GameObject lastObjectSpawned;
	void Start () {
		ObjectCount = 0;
		Debug.Log("Spawn script called");

	}
	
	void Update() {
		Spawn ();
	}

	void Spawn() {

		if (ObjectCount < 21) {
			Debug.Log ("Object Count is" + ObjectCount);
			//Debug.Log("screen width is "+Screen.width);
			if(ObjectCount == 0) {
				lastObjectSpawned =  Instantiate (obj [0], new Vector3(transform.position.x,transform.position.y,0), Quaternion.identity)as GameObject;
			}else {
				if(ScoreManager.getScore()<15) {
					lastObjectSpawned =  Instantiate (obj [Random.Range (1, obj.GetLength (0)/2)], new Vector3(transform.position.x, lastObjectSpawned.transform.position.y-tileheight,0), Quaternion.identity)as GameObject;
				}else {
					lastObjectSpawned =  Instantiate (obj [Random.Range (obj.GetLength (0)/2, obj.GetLength (0))], new Vector3(transform.position.x, lastObjectSpawned.transform.position.y-tileheight,0), Quaternion.identity)as GameObject;
				}
			}
				ObjectCount++;
			spawnPickables (lastObjectSpawned);

		} else {
				//Debug.Log("Working Fine"+ObjectCount);
		}


	}

	public static int ObjCount
	{ 
		get { return ObjectCount; }
		set { ObjectCount = value; }
		
	}

	void spawnPickables (GameObject lastObjectSpawned) {
	
		float x = Random.Range (Constants.COIN_SPAWN_LIMIT_LEFT, Constants.COIN_SPAWN_LIMIT_RIGHT) + 0.1f * (Random.Range (0, 9));
		int y = (int)lastObjectSpawned.transform.position.y + Random.Range(2,8);
		if (Random.Range (0, 3) == 0) {
			GameObject pickableElement = Instantiate (pickables [0], new Vector3 (x, y, 0), Quaternion.identity) as GameObject;	
			bool incrementXflag = false;
			int coinOrientation = Random.Range (0, 3);
			for (int i =0; i<5; i++) {
				if (coinOrientation == 1) {
						x = x + 0.3f;
				} else 
				if (coinOrientation == 2) {
						x = x - 0.3f;
				}
				pickableElement = Instantiate (pickables [0], new Vector3 (x, pickableElement.transform.position.y + 0.6f, 0), Quaternion.identity) as GameObject;
			}
		} else 
		if(Random.Range(0,3) == 2) {
			GameObject pickableElement = Instantiate (pickables [1], new Vector3 (x, y, 0), Quaternion.identity) as GameObject;	
		}else 
		if(Random.Range(0,3) == 2) {
			GameObject pickableElement = Instantiate (pickables [2], new Vector3 (x, y, 0), Quaternion.identity) as GameObject;	
			
		}

	}

}
