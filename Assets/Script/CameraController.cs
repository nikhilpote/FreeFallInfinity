using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	// Use this for initialization
	public GameObject objectToFollow;
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("width is " + Screen.width + " " + " height is " + Screen.height);
		transform.position = new Vector3 (0, objectToFollow.transform.position.y -4,-15);
		setFieldofView ();
	}

	float  getCameraZposition() {


		return (Screen.width*-11/159);
	}
	void setFieldofView() {
		
		double aspectRatio = ((double)Screen.width/(double)Screen.height);
		float difference = 0.66f - (float)aspectRatio;
		Debug.Log ("difference is " + difference);
		float increment = (difference*100) * 0.833f;
		float fieldView = 40 + increment;
		//Debug.Log ("aspect ratio is " + aspectRatio);
		camera.fieldOfView = fieldView;//(float)(aspectRatio*45/0.6);
	}
}
