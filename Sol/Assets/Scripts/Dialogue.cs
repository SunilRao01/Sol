using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Dialogue : MonoBehaviour
{
	// Dialogue Box
	private string currentDialogue;

	// Variables
	public bool complete;

	// Scrolling Text Effect
	public float letterPause = 0.1f;
	public float dialogueInterval;

	private string dialogueText;

	private bool scrollComplete;

	public List<string> dialogueList;
	private int iterator;

	private bool battleStart = true;
	public bool battleEnd = false;
	public bool flee = false;

	private GameObject enemyObject;

	public List<GameObject> dialogueObjects;

	void Start ()
	{
		iterator = 0;

		complete = false;
		scrollComplete = false;

		// Starting dialogue
		currentDialogue = dialogueList[iterator];
		
		startDialogue();

	}

	void Update ()
	{
		// Always keep the dialogue text updated
		GetComponent<Text>().text = dialogueText;
	}

	public void startDialogue()
	{
		dialogueText = "";
		iterator = 0;

		StartCoroutine(TypeText());
	}

	IEnumerator TypeText ()
	{
		// Display the text on a dialogue box letter-by-letter using a retro "blip" sound effect
		while (iterator < dialogueList.Count)
		{
			dialogueText = "";
			currentDialogue = dialogueList[iterator];
			scrollComplete = false;

			foreach (char letter in currentDialogue.ToCharArray())
			{
				dialogueText += letter;

				if (GetComponent<AudioSource>())
				{
					GetComponent<AudioSource>().Play();
				}

				// Wait a bit before displaying the next letter
				yield return new WaitForSeconds (letterPause);

			}

			// Wait so the user can read the sentence
			yield return new WaitForSeconds(dialogueInterval);

			scrollComplete = true;
			iterator++;
		}


		for (int i = 0; i < dialogueObjects.Count; i++)
		{
			dialogueObjects[i].SetActive(false);
		}
	}



}
