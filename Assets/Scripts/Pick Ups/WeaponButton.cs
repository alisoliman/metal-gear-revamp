using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WeaponButton : MonoBehaviour {

	public PlayerPickUp playerPickUp;

	public Text buttonName;
	public Text description;

	private Button button;

	public int weaponID;

	// Use this for initialization
	void Start () {
		button = GetComponent<Button> ();
		SetButton ();
	}

	void Update(){
		button.interactable = playerPickUp.WeaponsList [weaponID].enabled;
	}

	void SetButton()
	{
		buttonName.text = playerPickUp.WeaponsList [weaponID].name;
		description.text = playerPickUp.WeaponsList [weaponID].description;
	}

	public void OnClick(){

		// TO be done
	}
}
