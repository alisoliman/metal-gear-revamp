using System;
using UnityEngine;
using System.Collections;


	[RequireComponent(typeof (NavMeshAgent))]
	public class Boss : MonoBehaviour
	{
		public NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
		public GameObject character { get; private set; } // the character we are controlling
		public Transform target;                                    // target to aim for
		public float fieldOfViewAngle = 110f;
		public bool playerInSight;
		private SphereCollider col;
		private Animator anim;
		private bool walking;
		private GameObject player;
		private PlayerHealth playerHealth;


		private void Awake()
		{
			// get the components on the object we need ( should not be null due to require component so no need to check )
			agent = GetComponentInChildren<NavMeshAgent>();
			character = GameObject.FindGameObjectWithTag ("BigBoss");
			anim = GetComponent<Animator> ();
			col = GetComponent<SphereCollider> ();
			player = GameObject.FindGameObjectWithTag ("Player");
			playerHealth = player.GetComponent<PlayerHealth>();
			agent.updateRotation = false;
			agent.updatePosition = true;
			walking = true;
			agent.SetDestination(target.position);
		}


		private void Update()
		{

			if (playerInSight) {

				walking = false;
				agent.SetDestination (transform.position);
			} else {

				walking = true;
				agent.SetDestination(target.position);
			}

			updateState ();

		}

		void OnTriggerStay(Collider other){

			if (other.gameObject.CompareTag ("Player")) {

				playerInSight = false;
				Vector3 direction = other.transform.position - transform.position;
				float angle = Vector3.Angle (direction, transform.forward);

				if (angle < fieldOfViewAngle * 0.5f) {

					RaycastHit hit;
					if(Physics.Raycast(transform.position + transform.up, direction.normalized, out hit, col.radius)){

						if (hit.collider.gameObject == player) {
							playerInSight = true;
						}
					}

				}
			}
		}

		void OnTriggerExit(Collider other){

			if (other.gameObject.CompareTag ("Player")) {

				playerInSight = false;
			}
		}



			
		private void updateState(){
			anim.SetBool ("walking", walking);
		}

		public void setTarget (Transform target) {
		this.target = target;
		}

	}

