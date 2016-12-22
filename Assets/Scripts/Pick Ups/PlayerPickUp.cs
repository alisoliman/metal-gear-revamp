using UnityEngine;
using System.Collections.Generic;

public class PlayerPickUp : MonoBehaviour {

	public GameObject weaponPanel;
	public GameObject itemPanel;

	public GameObject CardBoard;
	public bool cardboardActivated;


	public WeaponObject [] WeaponsList;
	public int currentWeapon = 0;
	public ItemObject [] ItemsList;
	public int currentItem = 0;

	private ItemObject activatedItem;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.F)){
			OpenWeaponsPanel();
		}
		if (Input.GetKeyDown(KeyCode.R)){
			OpenItemsPanel();
		}
		if (Input.GetKeyDown(KeyCode.LeftAlt) || Input.GetKeyDown(KeyCode.RightAlt)){
			activatedItem = ItemsList[currentItem];
			if (activatedItem.itemName == "Cardboard"){
				this.gameObject.SetActive(false);
			}
		}
	}
		

	void OpenWeaponsPanel()
	{

		weaponPanel.SetActive (true);
		Time.timeScale = 0;
	}

	void OpenItemsPanel()
	{

		itemPanel.SetActive (true);
		Time.timeScale = 0;
	}

	public void CloseWeaponsPanel()
	{
		weaponPanel.SetActive (false);
		Time.timeScale = 1;
	}


	public void CloseItemsPanel()
	{
		itemPanel.SetActive (false);
		Time.timeScale = 1;
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.tag == "Weapon") {
			for (int i = 0; i < WeaponsList.Length; i++) {
				if (collider.gameObject.name == WeaponsList [i].assignedGameObject.name) {
					WeaponsList [i].enabled = true;
				}
			}
			collider.gameObject.SetActive (false);
		}
		if (collider.tag == "Item") {
			for (int i = 0; i < ItemsList.Length; i++) {
			if (collider.gameObject.name == ItemsList [i].assignedGameObject.name) {
					ItemsList [i].enabled = true;
				}
			}
			collider.gameObject.SetActive (false);
		}
	}
			}