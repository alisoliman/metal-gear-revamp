using System;
using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Characters.ThirdPerson
{
	[RequireComponent(typeof (NavMeshAgent))]
	[RequireComponent(typeof (ThirdPersonCharacter))]
	public class AICharacterControl : MonoBehaviour
	{
		public NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
		public ThirdPersonCharacter character { get; private set; } // the character we are controlling
		public Transform target;                                    // target to aim for
		public Transform target2;
		public Transform tmp;
		private Animator anim;
		private bool walking;
		private bool turn;
		Vector3 currentPosition;
		float originalXPosition;
		float timer;
		float timer2;
		bool decTime;
		int firstTarget;

		private void Start()
		{
			// get the components on the object we need ( should not be null due to require component so no need to check )
			agent = GetComponentInChildren<NavMeshAgent>();
			character = GetComponent<ThirdPersonCharacter>();
			anim = GetComponent<Animator> ();
			agent.updateRotation = false;
			agent.updatePosition = true;
			currentPosition = transform.parent.position;
			originalXPosition = transform.position.x;
			Debug.Log (originalXPosition);
			agent.SetDestination(target.position);
			timer = 3f;
			timer2 = 1.5f;
			decTime = false;
			walking = true;
			turn = false;
			firstTarget = 1;
		}


		private void Update()
		{
			followPath ();
			updateState();

			if (decTime) {
				turn = true;
				timer2 -= Time.deltaTime;
				transform.Rotate (Vector3.up * 118 * Time.deltaTime);
				Debug.Log ("Kam mara");
			}

			if (timer2 <= 0) {
				timer2 = 1.5f;
				turn = false;
				decTime = false;
				turn = false;
				walking = true;
				repositionTarget();

			}


		}
	private void followPath(){

		if (agent.remainingDistance <= agent.stoppingDistance + 0.25) {
			walking = false;
			timer -= Time.deltaTime;
			turn = true;
//			transform.LookAt (target2);
//			Vector3 pos = target.position = agent.SetDestination(target.position);
		}
		if (timer <= 0f) {
			decTime = true;
			timer = 4f;
		}
	}

		private void repositionTarget(){

			if(firstTarget == 1){
				target.position = new Vector3 (transform.position.x - 6, transform.position.y, transform.position.z);
				agent.SetDestination (target.position);
				firstTarget = 0;
			} else {
				target.position = new Vector3 (transform.position.x + 6, transform.position.y, transform.position.z);
				agent.SetDestination (target.position);
				firstTarget = 1;
			}
		}

		private void updateState(){
		
			if(walking == true)
				anim.SetBool ("walking", true);
			if(walking == false)
				anim.SetBool ("walking", false);
			if(turn == true)
				anim.SetBool ("turn", true);
			if(turn == false)
				anim.SetBool ("turn", false);
		}



		void doIt(){
			Debug.Log("After waiting 10 seconds");
		}

		public void waiter(){
			StartCoroutine(wait (4));
		}

		public void SetTarget(Transform target)
		{
			this.target = target;
		}
	
		IEnumerator wait(int t) {
			yield return new WaitForSeconds(t);

		}
	}
}
