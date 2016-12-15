using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WeaponButton : MonoBehaviour {

	public Text name;
	public Text Description;

	public int weaponID;

	// Use this for initialization
	void Start () {
		SetButton ();
	}


	void SetButton()
	{
//		name.text = PlayerPickUp.WeaponsList [PlayerPickUp.currentWeapon].name;
//		Description.text = PlayerPickUp.WeaponsList [PlayerPickUp.currentWeapon].description;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
