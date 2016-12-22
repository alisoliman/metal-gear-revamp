using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerPickUp : MonoBehaviour
{

	public GameObject weaponPanel;
	public GameObject itemPanel;
	public GameObject pausePanel;
	public GameObject winPanel;
	public GameObject finalWinPanel;

	public GameObject boss;
	private EnemyHealth bossHealth;

	private PlayerHealth playerHealth;

	public GameObject CardBoard;

	public GameObject [] destroyItems;

	private bool gamePaused;


	public Text itemText;
	public Text weaponText;

	public WeaponObject[] WeaponsList;
	public int currentWeapon = 0;
	public ItemObject[] ItemsList;
	public int currentItem = 0;

	private ItemObject activatedItem;

	public GameObject audioObject;
	public AudioSource audio;
	public AudioClip suspense;
	public AudioClip winning;

	void Start ()
	{
		boss.SetActive (false);
		bossHealth = boss.GetComponent<EnemyHealth> ();
		playerHealth = GetComponent<PlayerHealth> ();
		gamePaused = false;
		weaponText.text = WeaponsList [currentWeapon].weaponName;
		itemText.text = ItemsList [currentItem].itemName;
		audioObject = GameObject.FindGameObjectWithTag ("background");
		audio = audioObject.GetComponent<AudioSource> ();
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
			if (activatedItem.itemName == "First Aid") {
				if (playerHealth.currentHealth < 40) {
					playerHealth.currentHealth += 60;
				} else {
					playerHealth.currentHealth = 100;
				}
				activatedItem.enabled = false;
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
		if (bossHealth.currentHealth < 1) {
			finalWinPanel.SetActive (true);
			Time.timeScale = 0;
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
			if (collider.gameObject.name == "WinKey") {
				StartCoroutine (WinGame ());
			}

			collider.gameObject.SetActive (false);
		}
	}

	IEnumerator WinGame() {
		winPanel.SetActive (true);
		yield return new WaitForSeconds(5);
		winPanel.SetActive (false);
		for (int i = 0; i < destroyItems.Length; i++) {
			Destroy(destroyItems[i]);
		}

		boss.SetActive (true);

		bossAudio ();
	}

	public void bossAudio(){
	
		audio.Stop ();
		audio.clip = suspense;
		audio.Play ();
	}

	public void winAudio(){

		audio.Stop ();
		audio.clip = winning;
		audio.Play ();
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
		Time.timeScale = 1;
		SceneManager.LoadScene ("Intro");
	}
}