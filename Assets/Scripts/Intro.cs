using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class Intro : MonoBehaviour {
	public bool isMute;

	public GameObject MainPanel;
	public GameObject HowToPanel;
	public GameObject CreditsPanel;
	// Use this for initialization
	void Start () {
		isMute = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void MuteSoundClicked(){
		isMute = true;
		AudioListener.volume = isMute ? 0 : 1;
	}

	public void HowToPlayClicked(){
		MainPanel.SetActive (false);
		HowToPanel.SetActive (true);
	}

	public void CreditsClicked(){
		MainPanel.SetActive (false);
		CreditsPanel.SetActive (true);
	}

	public void StartGame(){
		SceneManager.LoadScene ("MainScene");
	}

	public void backHowTo(){
		MainPanel.SetActive (true);
		HowToPanel.SetActive (false);
	}

	public void backCredits(){
		MainPanel.SetActive (true);
		CreditsPanel.SetActive (false);
	}
}
