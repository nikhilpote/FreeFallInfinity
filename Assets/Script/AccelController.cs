using UnityEngine;
using System.Collections;
enum CharacterState {
	NORMAL =0 ,
	SLOW 

};
enum ParaChuteState {
	CLOSE =0,
	OPEN 
}

public class AccelController : MonoBehaviour {

	// Use this for initialization
	private float lastAccel;
	public float speed = 0.01f;
	public float movethreshold = 10.0f;
	public GameObject parachuteModel;
	private float iPx;
	private Vector2 lastVelocity ;
	private Animator characterAnimator;
	private Animator parachuteAnimator;
	void Start () {
		lastAccel = Input.acceleration.x;
		characterAnimator = gameObject.GetComponent<Animator> ();
		parachuteAnimator = parachuteModel.GetComponent<Animator> ();
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
		getInput();
	}

	void getInput() {
		
		foreach (Touch touch in Input.touches) {
			
			
			if (touch.phase == TouchPhase.Began) {
				//lastVelocity = rigidbody2D.velocity;
				rigidbody2D.drag = 5.0f;


				characterAnimator.SetInteger("characterState",(int)CharacterState.SLOW);
				parachuteAnimator.SetInteger("parachuteopen",(int)ParaChuteState.OPEN);
			}
			if (touch.phase == TouchPhase.Stationary) {
				//rigidbody.drag = rigidbody.drag+1;
			}
			if (touch.phase == TouchPhase.Ended) {
				rigidbody2D.drag = 0.5f;
				characterAnimator.SetInteger("characterState",(int)CharacterState.NORMAL);
				parachuteAnimator.SetInteger("parachuteopen",(int)ParaChuteState.CLOSE);
				//rigidbody2D.velocity = lastVelocity;
			} 
			
		} 
	}

	void OnCollisionEnter2D(Collision2D otherObject) {

		PlayerPrefs.SetInt ("score", (int)ScoreManager.getScore());
		Application.LoadLevel (1);

	}

}
