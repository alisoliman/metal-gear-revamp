﻿using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerPickUp : MonoBehaviour
{

	public GameObject weaponPanel;
	public GameObject itemPanel;
	public GameObject pausePanel;

	public GameObject CardBoard;

	private bool gamePaused;


	public Text itemText;
	public Text weaponText;

	public WeaponObject[] WeaponsList;
	public int currentWeapon = 0;
	public ItemObject[] ItemsList;
	public int currentItem = 0;

	private ItemObject activatedItem;
	// Use this for initialization
	void Start ()
	{
		gamePaused = false;
		weaponText.text = WeaponsList [currentWeapon].weaponName;
		itemText.text = ItemsList [currentItem].itemName;
	}


	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.F)) {
			OpenWeaponsPanel ();
		}
		if (Input.GetKeyDown (KeyCode.R)) {
			OpenItemsPanel ();
		}
		if (Input.GetKeyDown (KeyCode.LeftAlt) || Input.GetKeyDown (KeyCode.RightAlt)) {
			activatedItem = ItemsList [currentItem];
			if (activatedItem.itemName == "Cardboard") {
				Vector3 playerPosition = this.gameObject.transform.position;
				this.gameObject.SetActive (false);
				CardBoard.transform.position = playerPosition;
				CardBoard.SetActive (true);
			}
		}
		if (Input.GetKeyDown (KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) {
			if (gamePaused) {
				pausePanel.SetActive (false);
				Time.timeScale = 1;
				gamePaused = false;
			} else {
				pausePanel.SetActive (true);
				Time.timeScale = 0;
				gamePaused = true;
			}
		}
	}


	//Handle Panels

	void OpenWeaponsPanel ()
	{

		weaponPanel.SetActive (true);
		Time.timeScale = 0;
	}

	void OpenItemsPanel ()
	{

		itemPanel.SetActive (true);
		Time.timeScale = 0;
	}

	public void CloseWeaponsPanel ()
	{
		weaponPanel.SetActive (false);
		Time.timeScale = 1;
		weaponText.text = WeaponsList [currentWeapon].weaponName;
	}


	public void CloseItemsPanel ()
	{
		itemPanel.SetActive (false);
		Time.timeScale = 1;
		itemText.text = ItemsList [currentItem].itemName;
	}


	// Collect Items
	void OnTriggerEnter (Collider collider)
	{
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

	// Pause Related Methods
	public void ResumeClicked(){
		Time.timeScale = 1;
		pausePanel.SetActive (false);
		gamePaused = false;
	}

	public void RestartClicked(){
		Time.timeScale = 1;
		SceneManager.LoadScene(Application.loadedLevel);
	}

	public void QuitClicked(){
		
	}
}