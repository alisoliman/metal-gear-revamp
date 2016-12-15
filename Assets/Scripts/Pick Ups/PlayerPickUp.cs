using UnityEngine;
using System.Collections.Generic;

public class PlayerPickUp : MonoBehaviour {

	public WeaponObject [] WeaponsList;
	public static int currentWeapon = 0;
	public static List <GameObject> ItemsList;
	public static int currentItem = 0;

	// Use this for initialization
	void Start () {
//		WeaponsList = new List<WeaponObject> ();
		ItemsList = new List<GameObject> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.tag == "Weapon") {
//			WeaponsList.Add (collider.gameObject);
//			collider.gameObject.SetActive (false);
//			Debug.Log (WeaponsList.Count);
		}
		if (collider.tag == "Item") {
			ItemsList.Add (collider.gameObject);
			collider.gameObject.SetActive (false);
		}
	}
}
