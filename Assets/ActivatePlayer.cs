using UnityEngine;
using System.Collections;

public class ActivatePlayer : MonoBehaviour {

	public GameObject Player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.LeftAlt) || Input.GetKeyDown(KeyCode.RightAlt)){
			this.gameObject.SetActive (false);
			Player.SetActive (true);
		}
	
	}
}
