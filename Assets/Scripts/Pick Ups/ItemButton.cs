using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemButton : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler {

	public PlayerPickUp playerPickUp;
	public AudioClip hoverButtonClip;
	public AudioClip chooseButtonClip;
	private AudioSource audioSource;

	public Text buttonName;
	public Text description;

	private Button button;

	public int itemID;

	// Use this for initialization
	void Start () {
		button = GetComponent<Button> ();
		audioSource = GetComponent<AudioSource> ();
		SetButton ();
	}

	void Update(){
		button.interactable = playerPickUp.ItemsList [itemID].enabled;
	}

	void OnMouseEnter() {
		
//		Debug.Log ("here");
	}

	public void OnPointerEnter( PointerEventData ped ) {
		audioSource.PlayOneShot(hoverButtonClip);
	}

	public void OnPointerDown( PointerEventData ped ) {
//		audioSource.PlayOneShot(chooseButtonClip);
		audioSource.Play();
	}    

	void SetButton()
	{
		buttonName.text = playerPickUp.ItemsList [itemID].name;
		description.text = playerPickUp.ItemsList [itemID].description;
	}

	public void OnClick(){
		playerPickUp.currentItem = itemID;
		playerPickUp.CloseItemsPanel ();
	}
}
