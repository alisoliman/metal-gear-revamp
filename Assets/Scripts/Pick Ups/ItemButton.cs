using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour {

	public PlayerPickUp playerPickUp;

	public Text buttonName;
	public Text description;

	private Button button;

	public int itemID;

	// Use this for initialization
	void Start () {
		button = GetComponent<Button> ();
		SetButton ();
	}

	void Update(){
		button.interactable = playerPickUp.ItemsList [itemID].enabled;
	}

	void SetButton()
	{
		buttonName.text = playerPickUp.ItemsList [itemID].name;
		description.text = playerPickUp.ItemsList [itemID].description;
	}

	public void OnClick(){

		// TO be done
		playerPickUp.currentItem = itemID;
		playerPickUp.CloseItemsPanel ();
		Debug.Log (playerPickUp.currentItem);
	}
}
