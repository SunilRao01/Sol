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
				Debug.Log("Sound triggered for letter '" + letter.ToString() + "'!");

			}

			// Wait so the user can read the sentence
			yield return new WaitForSeconds(dialogueInterval);

			scrollComplete = true;
			iterator++;
		}


	}

	IEnumerator fleeRoutine(bool canFlee)
	{
		// Iterate through flee dialogue
		while (iterator < dialogueList.Count)
		{
			dialogueText = "";
			currentDialogue = dialogueList[iterator];
			scrollComplete = false;
			int count = 1;

			foreach (char letter in currentDialogue.ToCharArray())
			{
				dialogueText += letter;

				if (GetComponent<AudioSource>() && count % 1 == 0)
				{
					GetComponent<AudioSource>().Play();
					yield return 0;
				}
				yield return new WaitForSeconds (letterPause);

				count++;
			}

			yield return new WaitForSeconds(1);

			scrollComplete = true;
			iterator++;
		}
	}

	IEnumerator displayAttack()
	{
		iterator = 0;

		// Display attack dialogue
		while (iterator < dialogueList.Count)
		{
			dialogueText = "";
			currentDialogue = dialogueList[iterator];
			scrollComplete = false;
			int count = 1;

			foreach (char letter in currentDialogue.ToCharArray())
			{
				dialogueText += letter;

				if (GetComponent<AudioSource>() && count % 1 == 0)
				{
					GetComponent<AudioSource>().Play();
					yield return 0;
				}
				yield return new WaitForSeconds (letterPause);

				count++;
			}

			yield return new WaitForSeconds(1);

			scrollComplete = true;
			iterator++;
		}

		// Checks the speed stat of player/enemy to see who goes next
	}




}
