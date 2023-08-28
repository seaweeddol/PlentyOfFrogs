//NOTE: this script needs two ArtChar images in the canvas: Ragu and Jeda
//It also needs Char3Name and Char3Speech Text fields
//SceneChange button texts to "Run Away" and "Get Electrocuted".
//Re-drag all buttons into teh INspector script slots per the functions at the bottom.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio; 

public class Scene2aDialogue : MonoBehaviour { 
	public int primeInt = 1; // This integer drives game progress!
	public Text Char1name; 
	public Text Char1speech;
	public Text Char2name; 
	public Text Char2speech; 
	public Text Char3name;
	public Text Char3speech;
	public GameObject dialogue; 
	public GameObject ArtChar1; 
	public GameObject ArtChar2;
	public GameObject ArtBG1; 
	public GameObject Choice1a; 
	public GameObject Choice1b; 
	public GameObject nextButton; 
	public GameObject NextScene1Button;
	public GameObject NextScene2Button; 
	//public GameObject gameHandler; 
	//public AudioSource audioSource; 

	void Start(){
		dialogue.SetActive(false);
		ArtChar1.SetActive(false);
		ArtChar2.SetActive(false); 
		ArtBG1.SetActive(true);
		Choice1a.SetActive(false);
		Choice1b.SetActive(false);
		NextScene1Button.SetActive(false);
		NextScene2Button.SetActive(false); 
		nextButton.SetActive(true);
	}

	public void talking(){ 
		primeInt = primeInt + 1;
		// Simple "follow" story units: player hits "Next" button to show each unit
		if (primeInt == 1){
			// audioSource.Play();
		}
		else if (primeInt == 2){
			dialogue.SetActive(true);
			Char1name.text = ""; 
			Char1speech.text = "";
			Char2name.text = "You"; 
			Char2speech.text = "Hey, Rags! Are you here?";
			Char3name.text = ""; 
			Char3speech.text = "";
		} 
		if (primeInt == 3){ 
			ArtChar1.SetActive(true);
			Char1name.text = "Ragu"; 
			Char1speech.text = "You startled me! What do you want?";
			Char2name.text = ""; 
			Char2speech.text = "";
			Char3name.text = ""; 
			Char3speech.text = "";
		}
		else if (primeInt ==4){
			Char1name.text = ""; 
			Char1speech.text = "";
			Char2name.text = "You"; 
			Char2speech.text = "Rags, there is someone after you!";
			Char3name.text = ""; 
			Char3speech.text = "";
			//gameHandler.AddPlayerStat(1);
		} 
		else if (primeInt == 5){
			Char1name.text = "Ragu"; 
			Char1speech.text = "Someone? Who?";
			Char2name.text = ""; 
			Char2speech.text = "";
			Char3name.text = ""; 
			Char3speech.text = "";
		} 
		else if (primeInt == 6){
			Char1name.text = ""; 
			Char1speech.text = "";
			Char2name.text = "You"; 
			Char2speech.text = "I don't know. They were big, green, and had a badge. What did you do?"; 
			Char3name.text = ""; 
			Char3speech.text = "";
			//gameHandler.AddPlayerStat(1);
		} 
		else if (primeInt == 7){
			ArtChar1.SetActive(false);
			ArtChar2.SetActive(true); 
			Char1name.text = ""; 
			Char1speech.text = "";
			Char2name.text = ""; 
			Char2speech.text = "";
			Char3name.text = "Jeda";
			Char3speech.text = "He broke the law. And so did you, running from me. Now I take you both in.";
		} 
		else if (primeInt ==8){
			ArtChar1.SetActive(true);
			ArtChar2.SetActive(false);
			Char1name.text = "Ragu"; 
			Char1speech.text = "Flark! You led her right to me!";
			Char2name.text = ""; 
			Char2speech.text = "";
			Char3name.text = ""; 
			Char3speech.text = "";
		} 
		else if (primeInt ==9){
			Char1name.text = ""; 
			Char1speech.text = "";
			Char2name.text = "You"; 
			Char2speech.text = "I didn't! I swear!";
			Char3name.text = ""; 
			Char3speech.text = "";
		} 
		else if (primeInt == 10){
			Char1name.text = "Ragu"; 
			Char1speech.text = "Help me! Together we can take her down!";
			Char2name.text = ""; 
			Char2speech.text = "";
			Char3name.text = ""; 
			Char3speech.text = "";
			// Turn off "Next" button, turn on "Choice" buttons
			nextButton.SetActive(false);
			Choice1a.SetActive(true); // function Choice1aFunct()
			Choice1b.SetActive(true); // function Choice1bFunct()
		} 
		// ENCOUNTER AFTER CHOICE #1
		else if (primeInt == 100){
			Char1name.text = "Ragu"; 
			Char1speech.text = "Where are you going? Don't leave me!";
			Char2name.text = ""; 
			Char2speech.text = "";
			Char3name.text = ""; 
			Char3speech.text = "";

		} 
		else if (primeInt == 101){ 
			ArtChar1.SetActive(false);
			ArtChar2.SetActive(true);
			Char1name.text = ""; 
			Char1speech.text = "";
			Char2name.text = ""; 
			Char2speech.text = "";
			Char3name.text = "Jeda"; 
			Char3speech.text = "Hands behind your back, Ragu! You're done.";
			nextButton.SetActive(false);
			NextScene1Button.SetActive(true);
		} 
		else if (primeInt == 200){
			ArtChar1.SetActive(false);
			ArtChar2.SetActive(true);
			Char1name.text = "";
			Char1speech.text = "";
			Char2name.text = "";
			Char2speech.text = "";
			Char3name.text = "Jeda";
			Char3speech.text = "What do you stupids think you are doing?";

		} 
		else if (primeInt == 201){
			Char1name.text = "";
			Char1speech.text = "";
			Char2name.text = "";
			Char2speech.text = "";
			Char3name.text = "Jeda";
			Char3speech.text = "Ow. That's it. Eat my laser club.";
			nextButton.SetActive(false);
			NextScene2Button.SetActive(true);
		} 
	} 

	// FUNCTIONS FOR BUTTONS TO ACCESS (Choice #1 and switch scenes)
	public void Choice1aFunct(){
		Char1name.text = ""; 
		Char1speech.text = "";
		Char2name.text = "You"; 
		Char2speech.text = "You are out of your slimy green mind!";
		primeInt = 99;
		Choice1a.SetActive(false);
		Choice1b.SetActive(false);
		nextButton.SetActive(true);
	} 
	public void Choice1bFunct(){ 
		Char1name.text = ""; 
		Char1speech.text = ""; 
		Char2name.text = "You"; 
		Char2speech.text = "Fine -- you go low, I'll go high!";
		primeInt = 199;
		Choice1a.SetActive(false);
		Choice1b.SetActive(false);
		nextButton.SetActive(true);
	}

	public void SceneChange2a(){
		SceneManager.LoadScene("SceneWin");
	} 
	public void SceneChange2b(){ 
		SceneManager.LoadScene("SceneLose");
	}
}
