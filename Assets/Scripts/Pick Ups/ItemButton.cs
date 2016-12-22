using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour {

	public PlayerPickUp playerPickUp;
	public AudioClip hoverButtonClip;

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
		audioSource.PlayOneShot(hoverButtonClip);
		Debug.Log ("here");
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
