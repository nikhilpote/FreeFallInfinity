using UnityEngine;
using System.Collections;

public class BackgroundScrolls : MonoBehaviour {

	// Use this for initialization
	public float speed= 0;
	
	// Update is called once per frame
	void Update () {
		renderer.material.mainTextureOffset = new Vector2 (0.0f, -(Time.time * speed));
	}
}
