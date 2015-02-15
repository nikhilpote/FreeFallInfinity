using UnityEngine;
using System.Collections;

public class CoinController : MonoBehaviour {


	void OnTriggerEnter2D(Collider2D collider) {
		//Destroy (gameObject);

	}
	void AddDamage(GameObject player)	{
		transform.position = Vector3.MoveTowards (transform.position, player.transform.position, 10.0f * Time.deltaTime);
		//Debug.Log("This function was called from a script attached to GameObjectA");
	} 
}
