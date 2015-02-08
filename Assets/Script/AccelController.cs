using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using pickable;

enum CharacterState {
	NORMAL =0 ,
	SLOW 

};
enum ParaChuteState {
	CLOSE =0,
	OPEN 
}
namespace Player {
	public  class AccelController : MonoBehaviour {

		// Use this for initialization
		private float lastAccel;
		public float speed = 0.01f;
		public float movethreshold = 10.0f;
		public GameObject parachuteModel;
		private float iPx;
		private Vector2 lastVelocity ;
		private Animator characterAnimator;
		private Animator parachuteAnimator;
		public GameObject Panel_Parachute_health;
		PlayerCollision playerCollisions;
		Parachute_health parachutehealth;
		public static  bool isParachuteHealthZero;
		public static bool isParachuteOpen;
		void Start () {
			lastAccel = Input.acceleration.x;
			characterAnimator = gameObject.GetComponent<Animator> ();
			parachuteAnimator = parachuteModel.GetComponent<Animator> ();
			playerCollisions = new PlayerCollision ();
			isParachuteHealthZero = false;
			isParachuteOpen = false;
			parachutehealth = Panel_Parachute_health.GetComponent<Parachute_health> ();
		}
		
		// Update is called once per frame
		void Update () {
			/*float accel = Input.acceleration.x;
			float xShift = transform.position.x;
			if (lastAccel < accel) {
				xShift 
			}
			lastAccel = accel;*/

			/*iPx = Input.acceleration.x;
			if (Mathf.Abs (iPx) > movethreshold) {
				float movex = Mathf.Sign(iPx)*speed;
				this.transform.Rotate(0,iPx,0,)

			}


			lastAccel = Input.acceleration.x;
		//	lastAccel = Random.Range (-0.1f, -0.2f);
			float roundedaccel = Mathf.CeilToInt (Input.acceleration.x * 10);
			 //roundedaccel = Mathf.CeilToInt (Random.Range(-10,10));

			if(roundedaccel<lastAccel) {
				// tiltTransform = new Vector3 (,transform.position.y,0)*Time.deltaTime;
				 transform.Translate( Vector3.left);
			}else if(roundedaccel> lastAccel) {
				//tiltTransform = new Vector3 (,transform.position.y,0)*Time.deltaTime;
				transform.Translate( Vector3.right);
			}
			//transform.Translate (tiltTransform);
			lastAccel = roundedaccel;*/
			//float roundedaccel = Mathf.CeilToInt (Input.acceleration.x * 10);

			transform.Translate(Input.acceleration.x*Time. smoothDeltaTime*10, 0, 0);
			//transform.position = new Vector3 (roundedaccel, transform.position.y, transform.position.z);
			//rigidbody2D.velocity.Set (0, -20);

			updatePerFrame();
			PickableManager.updateTimers (Time.deltaTime);

		}

		void updatePerFrame() {
			
			foreach (Touch touch in Input.touches) {
				
				
				if (touch.phase == TouchPhase.Began) {
					//lastVelocity = rigidbody2D.velocity;

						openParachute();

				}
				if (touch.phase == TouchPhase.Stationary) {
					//rigidbody.drag = rigidbody.drag+1;
				}
				if (touch.phase == TouchPhase.Ended) {

						closeParachute();

					//rigidbody2D.velocity = lastVelocity;
				} 
				
			} 

			if (PickableManager.isTimerOnforItem (Constants.MAGNET)) {
				Collider2D [] colliders = Physics2D.OverlapCircleAll (transform.position, 5);
				int i = 0;
				while (i < colliders.Length) {
					Debug.Log("Tag of the object "+colliders[i].gameObject.tag);
					if(colliders[i].gameObject.tag == Constants.COIN) {
						Debug.Log("Inside sphere");
						colliders[i].gameObject.SendMessage("AddDamage",gameObject);
						
					}
					i++;
				}
			}
			if (isParachuteHealthZero) {
				closeParachute();
			}
			if (isParachuteOpen) {
				parachutehealth.decrementScrollSize();
			} else {
				parachutehealth.incrementScrollSize();
			}
		}

		void OnCollisionEnter2D(Collision2D otherObject) {
			Debug.Log ("Other object tag is " + otherObject.gameObject.tag);
			playerCollisions.checkCollisions (otherObject.gameObject.tag);

		}

		void OnTriggerEnter2D(Collider2D collider) {
			Debug.Log("Trigger Entered");
			playerCollisions.checkCollisions (collider.gameObject.tag);
			Destroy (collider.gameObject);
		}

		void openParachute() {
			if (!isParachuteOpen) {
				rigidbody2D.drag = 5.0f;
				characterAnimator.SetInteger ("characterState", (int)CharacterState.SLOW);
				parachuteAnimator.SetInteger ("parachuteopen", (int)ParaChuteState.OPEN);
				isParachuteOpen = true;
			}
		}

		void closeParachute() {
			if (isParachuteOpen) {
				rigidbody2D.drag = 0.5f;
				characterAnimator.SetInteger ("characterState", (int)CharacterState.NORMAL);
				parachuteAnimator.SetInteger ("parachuteopen", (int)ParaChuteState.CLOSE);
				isParachuteOpen = false;
			}
		}

		public static void  setHealthZero(bool value) {
			isParachuteHealthZero = value;
		}
	}

	public class PlayerCollision {

		List <string> listPickableCollisionObject;
		List <string> listObstacleCollisionObject;
		PickableManager pickableManager;

		public PlayerCollision() {
			listPickableCollisionObject = new List<string> ();
			listObstacleCollisionObject = new List<string> ();
			listPickableCollisionObject.Add (Constants.COIN);
			listPickableCollisionObject.Add (Constants.COINDOUBLER);
			listPickableCollisionObject.Add (Constants.MAGNET);
			listObstacleCollisionObject.Add (Constants.OBSTACLE);
			pickableManager = new PickableManager ();

		}

		public void checkCollisions(string objectTag) {
			if (listPickableCollisionObject.Contains (objectTag)) {
				pickableManager.incrementItemCountfor (objectTag);
			} else 
			if (listObstacleCollisionObject.Contains (objectTag)) {
				PlayerPrefs.SetInt ("score", (int)ScoreManager.getScore());
				Application.LoadLevel (1);
			}
		}
	}
}
