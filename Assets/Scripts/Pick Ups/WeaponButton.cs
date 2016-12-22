using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WeaponButton : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler  {

	public PlayerPickUp playerPickUp;

	public Text buttonName;
	public Text description;
	public AudioClip hoverButtonClip;
	public AudioClip chooseButtonClip;
	private AudioSource audioSource;
	private Button button;

	public int weaponID;

	// Use this for initialization
	void Start () {
		button = GetComponent<Button> ();
		SetButton ();
		audioSource = GetComponent<AudioSource> ();
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
		playerPickUp.currentWeapon = weaponID;
		playerPickUp.CloseWeaponsPanel ();
	}

	public void OnPointerEnter( PointerEventData ped ) {
		audioSource.PlayOneShot(hoverButtonClip);
	}

	public void OnPointerDown( PointerEventData ped ) {
		audioSource.PlayOneShot(chooseButtonClip);
		//		SoundManager.Play("MouseClickButton");
	}    
}
