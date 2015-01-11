using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

	// Use this for initialization
	public GameObject[] obj;
	public GameObject player;
	public float spawnmin = 1.0f;
	public float spawnmax = 2.0f;
	private static float ObjectCount;
	public float tileheight;
	private GameObject lastObjectSpawned;
	void Start () {
		ObjectCount = 0;

		Spawn ();
	}
	


	void Spawn() {
		if (ObjectCount < 21) {
			if(ObjectCount == 0) {
				lastObjectSpawned =  Instantiate (obj [Random.Range (0, obj.GetLength (0))], transform.position, Quaternion.identity)as GameObject;
			}else {
				lastObjectSpawned =  Instantiate (obj [Random.Range (0, obj.GetLength (0))], new Vector3(transform.position.x, lastObjectSpawned.transform.position.y-tileheight,transform.position.z), Quaternion.identity)as GameObject;
			}
						ObjectCount++;
				} else {
			Debug.Log("Working Fine"+ObjectCount);
				}

		Invoke ("Spawn", Random.Range (spawnmin, spawnmax));
	}

	public static float ObjCount
	{ 
		get { return ObjectCount; }
		set { ObjectCount = value; }
		
	}

}
