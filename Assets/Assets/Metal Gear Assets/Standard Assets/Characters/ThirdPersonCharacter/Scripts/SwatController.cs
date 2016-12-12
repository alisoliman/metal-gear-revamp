using UnityEngine;
using System.Collections;

public class SwatController : MonoBehaviour {
	Animator anim;
	bool idle;
	bool walking;
	bool sprinting;
	bool backward;
	bool right;
	bool left;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		idle = true;
		walking = false;
		sprinting = false;
		backward = false;
		right = false;
		left = false;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey ("w")) {
			idle = false;
			walking = true;
			sprinting = false;
			backward = false;
			right = false;
			left = false;
			transform.Translate (Vector3.forward  * Time.deltaTime);

			if (Input.GetKey (KeyCode.LeftShift)) {
				idle = false;
				sprinting = true;
				walking = true;
				backward = false;
				right = false;
				left = false;
				transform.Translate (Vector3.forward * 2 * Time.deltaTime);
			}
		}

		if (Input.GetKeyUp(KeyCode.LeftShift))
		{
			idle = false;
			walking = true;
			sprinting = false;
			backward = false;
			right = false;
			left = false;
			sprinting = false;
		}

		if (Input.GetKeyUp("w"))
		{
			idle = true;
			walking = false;
			sprinting = false;
			backward = false;
			right = false;
			left = false;
		}

		if (Input.GetKey ("s")) {
			idle = false;
			backward = true;
			walking = false;
			sprinting = false;
			right = false;
			left = false;
			transform.Translate (Vector3.back  * Time.deltaTime);
		}

		if (Input.GetKeyUp("s"))
		{
			idle = true;
			backward = false;
			walking = false;
			sprinting = false;
			right = false;
			left = false;
		}

		if (Input.GetKey ("d")) {
			idle = false;
			right = true;
			walking = false;
			sprinting = false;
			backward = false;
			left = false;
			transform.Rotate (Vector3.up * 100 * Time.deltaTime);
		}

		if (Input.GetKeyUp("d"))
		{
			idle = true;
			right = false;
			walking = false;
			sprinting = false;
			backward = false;
			left = false;
		}

		if (Input.GetKey ("a")) {
			idle = false;
			left = true;
			walking = false;
			sprinting = false;
			backward = false;
			right = false;
			transform.Rotate (Vector3.up * -100 * Time.deltaTime);
		}

		if (Input.GetKeyUp("a"))
		{
			idle = true;
			left = false;
			walking = false;
			sprinting = false;
			backward = false;
			right = false;
		}



	

		anim.SetBool ("Walking", walking);
		anim.SetBool ("Idle", idle);
		anim.SetBool ("Sprinting", sprinting);
		anim.SetBool ("Backward", backward);
		anim.SetBool ("Right", right);
		anim.SetBool ("Left", left);
	}
		
}
