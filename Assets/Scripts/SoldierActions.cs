using UnityEngine;
using System.Collections;

public class SoldierActions : MonoBehaviour {

	private NavMeshAgent enemy;
	public Transform target;
	public Transform target2;
	// Use this for initialization
	void Start () {
		enemy = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		enemy.SetDestination (target.position);

		if (enemy.transform.position.x == target.position.x &&
			enemy.transform.position.z == target.position.z) {
			target = target2;
		}
	}
}
