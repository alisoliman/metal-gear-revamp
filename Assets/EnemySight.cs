using UnityEngine;
using System.Collections;

public class EnemySight : MonoBehaviour {

	public float fieldOfViewAngle = 110f;
	public bool playerInSight;
	private NavMeshAgent nav;
	private SphereCollider col;
	public GameObject GameOverPanel;
	private Animator anim;
	private GameObject player;
	private Animator playerAnim;
	//private PlayerHealth playerHealth;

	void Awake(){

		nav = GetComponent<NavMeshAgent> ();
		col = GetComponent<SphereCollider> ();
		anim = GetComponent<Animator> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		playerAnim = player.GetComponent<Animator> ();
		//playerHealth = player.GetComponent<PlayerHealth>();

	}

	void Update(){
	
//		if(playerHealth.currentHealth > 0){
//			Set gameOver
//		}
		if (playerInSight) {
			Debug.Log ("BUSTEEEED!");
//			GameOver ();
			//playerHealth.currentHealth = 0;
		}
		
	
	}

	void GameOver(){
		GameOverPanel.SetActive (true);
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

	float CalculatePathLength(Vector3 targetPosition){

		NavMeshPath path = new NavMeshPath ();
		if (nav.enabled) {
			nav.CalculatePath (targetPosition, path);
		}
					Vector3[] allWayPoints = new Vector3[path.corners.Length + 2];
						
		allWayPoints [0] = transform.position;
		allWayPoints [allWayPoints.Length - 1] = targetPosition;

		for (int i = 0; i < path.corners.Length-1; i++) {
						allWayPoints [i + 1] = path.corners [i];
		}

		float pathLength = 0f;

		for (int i = 0; i < allWayPoints.Length - 1; i++) {
			pathLength += Vector3.Distance (allWayPoints [i], allWayPoints [i + 1]);
		}

		return pathLength;
	}

}
